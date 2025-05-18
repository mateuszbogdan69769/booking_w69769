import { ValidationHelper } from './../helpers/ValidationHelper';
import { IValidationResult } from '@/interfaces/IValidationResult';

export class UserCredentials {
  name = '';
  email = '';
  password = '';

  get v$(): IValidationResult {
    return {
      name: {
        required: {
          $validator: !!this.name,
          $message: 'Imię jest wymagane'
        }
      },
      email: {
        required: {
          $validator: !!this.email,
          $message: 'E-mail jest wymagany'
        },
        valid: {
          $validator: !!this.email && ValidationHelper.isEmailValid(this.email),
          $message: 'E-mail nie jest prawidłowy'
        }
      },
      password: {
        required: {
          $validator: !!this.password,
          $message: 'Hasło jest wymagane'
        }
      }
    };
  }
}
