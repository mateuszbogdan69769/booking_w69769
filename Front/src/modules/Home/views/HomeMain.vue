<template>
  <div class="home-view">
    <template v-if="!loading">
      <span>Rezerwacje ogólnie: {{ stats.totalBookings }}</span>

      <span>Rezerwacje dzisiaj: {{ stats.bookingsToday }}</span>

      <span>Goście ogólnie: {{ stats.totalGuests }}</span>

      <span>Goście dzisiaj: {{ stats.peoplesToday }}</span>
    </template>

    <Spinner v-else />
  </div>
</template>
<script lang="ts" setup>
import { Stats } from '@/ApiModels/Stats';
import { onMounted, ref } from 'vue';
import { getStatistics } from '../home.service';
import Spinner from '@/components/Spinner.vue';

const stats = ref(new Stats());
const loading = ref(false);

async function loadStats(): Promise<void> {
  loading.value = true;
  stats.value = await getStatistics();
  loading.value = false;
}

onMounted(loadStats);
</script>
<style lang="scss" scoped>
.home-view {
  display: flex;
  flex-direction: column;
}
</style>
