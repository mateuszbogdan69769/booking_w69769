import { Booking } from '@/ApiModels/Booking';
import { defineStore } from 'pinia';
import { MessageModel } from '@/models/MessageModel';
import { MessageTypeEnum } from '@/enums/MessageTypeEnum';
import { Guest } from '@/ApiModels/Guest';
import { createGuest, deleteGuest, getGuests, updateGuest } from './guests.services';
import { GuestViewModel } from './models/GuestViewModel';

interface IGuestsStoreState {
  guests: Guest[];
}

const baseState = (): IGuestsStoreState => ({
  guests: [],
});

export const useGuestsStore = defineStore('guest', {
  state: baseState,
  actions: {
    async loadGuests(searchValue=""): Promise<void> {
      this.guests = await getGuests(searchValue);
    },
    async addGuest(data: GuestViewModel): Promise<void> {
      const msg = new MessageModel(
        MessageTypeEnum.Success,
        'Osoba utworzona pomyślnie'
      );

      await createGuest(data, msg);

      this.loadGuests();
    },
    async editGuest(data: GuestViewModel): Promise<void> {
      const msg = new MessageModel(
        MessageTypeEnum.Success,
        'Dane osoby zostały zaktualizowane'
      );

      await updateGuest(data, msg);

      this.loadGuests();
    },
    async deleteGuest(id: number): Promise<void> {
      const msg = new MessageModel(
        MessageTypeEnum.Success,
        'Osoba usunięta pomyślnie'
      );

      await deleteGuest(id, msg);

      this.loadGuests();
    }
  },
  getters: {}
});
