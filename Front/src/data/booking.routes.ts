import { BookingsRoutes } from '@/modules/Bookings/bookings.routes';
import { GuestsRoutes } from '@/modules/Guests/guests.routes';
import { HomeRoutes } from '@/modules/Home/home.routes';

export const BookingRoutes = [
  ...HomeRoutes,
  ...BookingsRoutes,
  ...GuestsRoutes
];
