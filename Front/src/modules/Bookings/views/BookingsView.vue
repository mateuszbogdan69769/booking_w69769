<template>
  <div class="bookings-view">
    <div class="bookings-view__header">
      <v-btn color="blue" variant="tonal" @click="addBooking">Dodaj rezerwacje</v-btn>
    </div>

    <div class="bookings-view__content">
      <v-data-table
        :headers="BookingTableHeaders"
        :items="bookingsStore.bookings"
        :items-per-page="25"
        no-data-text="Brak rezerwacji"
        :loading="globalStore.loading"
      >
        <template #item.startDate="{ item }">
          <span>{{ DateHelper.GetDisplayDateInCurrentTimeZone(item.startDate) }}</span>
        </template>

        <template #item.endDate="{ item }">
          <span>{{ DateHelper.GetDisplayDateInCurrentTimeZone(item.endDate) }}</span>
        </template>

        <template #item.guest="{ item }">
          <span>{{ item.guest.fullName }}</span>
        </template>

        <template #item.actions="{ item }">
          <div class="d-flex justify-center">
            <v-icon
              color="medium-emphasis"
              icon="mdi-pencil"
              size="small"
              class="mr-2"
              @click="editBooking(item.id)"
            />

            <v-icon
              color="medium-emphasis"
              icon="mdi-delete"
              size="small"
              @click="openDeleteDialog(item.id)"
            />
          </div>
        </template>
      </v-data-table>
    </div>
  </div>

  <v-dialog v-model="dialogVisible" max-width="500">
    <v-card
      :subtitle="isEditing ? 'Edycja rezerwacji' : 'Dodaj rezerwacje'"
      :title="isEditing ? 'Edytuj' : 'Dodaj'"
    >
      <template #text>
        <div class="d-flex flex-column">
          <TextField
            v-model="bookingData.name"
            :disabled="isEditing"
            label="Imię"
            placeholder="Jan"
          />

          <TextField
            v-model="bookingData.surname"
            :disabled="isEditing"
            label="Nazwisko"
            placeholder="Kowalski"
          />

          <v-number-input
            v-model="bookingData.partySize"
            :max="20"
            :min="1"
            density="compact"
            variant="outlined"
            label="Ilość gości"
          />

          <div class="d-flex mb-5 ga-5">
            <DatePicker v-model="bookingData.startDate" label="Start rezerwacji" />

            <TimePicker v-model="bookingData.startDate" />
          </div>

          <div class="d-flex mb-5 ga-5">
            <DatePicker v-model="bookingData.endDate" label="Koniec rezerwacji" />

            <TimePicker v-model="bookingData.endDate" />
          </div>

          <v-textarea
            v-model="bookingData.note"
            label="Notatka"
            density="compact"
            variant="outlined"
            hide-details
          />
        </div>
      </template>

      <v-divider></v-divider>

      <v-card-actions class="bg-surface-light">
        <v-btn text="Anuluj" variant="plain" @click="dialogVisible = false" />

        <v-spacer />

        <v-btn :text="isEditing ? 'Edytuj' : 'Zapisz'" @click="handleSaveClick" />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script lang="ts" setup>
import DatePicker from '../../../components/DatePicker.vue';
import TimePicker from '../../../components/TimePicker.vue';
import { onMounted, ref } from 'vue';
import { useBookingsStore } from '../bookings.store';
import { BookingTableHeaders } from '../data/BookingTableHeaders';
import { DateHelper } from '@/helpers/DateHelper';
import { BookingViewModel } from '../models/BookingViewModel';
import { useConfirmationDialog } from '@/helpers/useConfirmationDialog';
import TextField from '@/components/TextField.vue';
import { useSearchStore } from '@/stores/search.store';
import { watchDebounced } from '@vueuse/core';
import { useGlobalStore } from '@/stores/global.store';

const bookingsStore = useBookingsStore();
const searchStore = useSearchStore();
const globalStore = useGlobalStore();

const isEditing = ref(false);
const dialogVisible = ref(false);

const bookingData = ref(new BookingViewModel());

function addBooking(): void {
  isEditing.value = false;
  bookingData.value = new BookingViewModel();
  dialogVisible.value = true;
}

function editBooking(id: number): void {
  const booking = bookingsStore.bookings.find((b) => b.id === id);
  if (!booking) return;

  isEditing.value = true;
  bookingData.value.setFromBooking(booking);
  dialogVisible.value = true;
}

async function openDeleteDialog(id: number): Promise<void> {
  const booking = bookingsStore.bookings.find((b) => b.id === id);
  if (!booking) return;

  const title = 'Usuwanie rezerwacji';
  const message = `Czy na pewno chcesz usunąć rezerwację "${booking.guest.fullName}"?`;
  const confirmed = await useConfirmationDialog({ title, message });
  if (!confirmed) return;

  await bookingsStore.deleteBooking(id);
}

async function handleSaveClick(): Promise<void> {
  if (isEditing.value) {
    await bookingsStore.editBooking(bookingData.value);
  } else {
    await bookingsStore.addBooking(bookingData.value);
  }

  dialogVisible.value = false;
}

watchDebounced(
  () => searchStore.searchBarValue,
  (v) => {
    bookingsStore.filter.searchQuery = v;
    bookingsStore.loadBookings();
  },
  { debounce: 250, maxWait: 500 }
);

onMounted(bookingsStore.loadBookings);
</script>
<style lang="scss" scoped>
.bookings-view {
  display: flex;
  flex-direction: column;
  gap: 25px;
  flex-grow: 1;
  &__header {
    display: flex;
    gap: 15px;
  }
  &__content {
    flex-grow: 1;
    .v-data-table {
      flex-grow: 1;
      height: 100%;
    }
  }
}
</style>
