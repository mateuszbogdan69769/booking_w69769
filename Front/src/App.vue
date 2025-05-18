<template>
  <v-app>
    <router-view />

    <Loader v-if="globalStore.loading" />
    <GlobalStoreMessage />
    <GlobalConfirmationDialog />
  </v-app>
</template>
<script lang="ts" setup>
import GlobalConfirmationDialog from './components/GlobalConfirmationDialog.vue';
import GlobalStoreMessage from './components/GlobalStoreMessage.vue';
import { useGlobalStore } from './stores/global.store';

const globalStore = useGlobalStore();
</script>
<style lang="scss">
@import '../src/styles/global.scss';

#app {
  height: 100%;
  overflow: hidden;
}
</style>
