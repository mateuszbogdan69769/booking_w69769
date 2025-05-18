import { defineStore } from 'pinia';

interface IGlobalStoreState {
  apiUrl: string;
  pendingRequests: number;
  navigationOpened: boolean;
}

const baseState = (): IGlobalStoreState => ({
  apiUrl:
    'https://bookingapi-fmgramdgageqesf2.polandcentral-01.azurewebsites.net/',
  pendingRequests: 0,
  navigationOpened: false
});

export const useGlobalStore = defineStore('global', {
  state: baseState,
  actions: {
    async useLoading<T>(handler: () => Promise<T>) {
      try {
        this.pendingRequests++;
        return await handler();
      } finally {
        this.pendingRequests--;
      }
    }
  },
  getters: {
    loading(): boolean {
      return this.pendingRequests > 0;
    }
  }
});
