import { Booking } from '@/ApiModels/Booking';
import { DateTimeTransformer } from '@/helpers/DateTimeTransformer';
import { Transform } from 'class-transformer';
import { DateTime } from 'luxon';

export class BookingViewModel {
  id = 0;
  name = '';
  surname = '';
  @Transform(DateTimeTransformer)
  startDate = DateTime.utc().plus({ hour: 1 }).startOf('hour');
  @Transform(DateTimeTransformer)
  endDate = DateTime.utc().plus({ hour: 1 }).startOf('hour').plus({ hour: 1 });
  partySize = 1;
  note = '';

  setFromBooking(booking: Booking): void {
    this.id = booking.id;
    this.name = booking.guest.name;
    this.surname = booking.guest.surname;
    this.startDate = booking.startDate;
    this.endDate = booking.endDate;
    this.partySize = booking.partySize;
    this.note = booking.note;
  }
}
