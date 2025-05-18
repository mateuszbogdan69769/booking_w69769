<template>
  <v-navigation-drawer class="bg-deep-purple pt-5" theme="dark" permanent>
    <v-list>
      <v-list-item
        v-for="(item, index) in BookingMenuItems"
        :key="index"
        :to="item.to"
        link
      >
        <div class="d-flex align-center">
          <v-icon class="mr-2">{{ item.iconName }}</v-icon>

          <v-list-item-title>
            {{ item.title }}
          </v-list-item-title>
        </div>
      </v-list-item>
    </v-list>

    <template v-slot:append>
      <div class="pa-2">
        <v-btn block @click="showLogoutDialog"> Wyloguj się </v-btn>
      </div>
    </template>
  </v-navigation-drawer>
</template>
<script lang="ts" setup>
import { BookingMenuItems } from '@/data/BookingMenuItems';
import { useConfirmationDialog } from '@/helpers/useConfirmationDialog';
import { useAccountStore } from '@/stores/account.store';

const accountStore = useAccountStore();

async function showLogoutDialog(): Promise<void> {
  const title = 'Czy na pewno chcesz się wylogować?';
  const confirmed = await useConfirmationDialog({ title });
  if (!confirmed) return;

  accountStore.logout();
}
</script>
<style lang="scss" scoped>
.v-navigation-drawer {
  position: static !important;
}
</style>
