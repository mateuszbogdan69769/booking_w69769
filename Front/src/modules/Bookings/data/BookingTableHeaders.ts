import { Booking } from '@/ApiModels/Booking';
import { ITableHeader } from '@/interfaces/ITableHeader';

export const BookingTableHeaders: ITableHeader<Booking>[] = [
  {
    title: 'Start',
    key: 'startDate'
  },
  {
    title: 'Koniec',
    key: 'endDate'
  },
  {
    title: 'Gość',
    key: 'guest'
  },
  {
    title: 'Ilość osób',
    key: 'partySize'
  },
  {
    title: 'Notatka',
    key: 'note'
  },
  {
    title: 'Akcje',
    key: 'actions',
    align: 'center'
  }
];
