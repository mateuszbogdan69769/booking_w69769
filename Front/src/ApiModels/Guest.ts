import { Type } from 'class-transformer';
import { Booking } from './Booking';

export class Guest {
  id = 0;
  name = '';
  surname = '';
  @Type(() => Booking)
  bookings: Booking[] | null = null;

  get fullName(): string {
    return `${this.name} ${this.surname}`;
  }
}
