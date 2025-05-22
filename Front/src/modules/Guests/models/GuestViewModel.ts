import { Guest } from "@/ApiModels/Guest";
import { GlobalHelper } from "@/helpers/GlobalHelper";
import { IValidationResult } from "@/interfaces/IValidationResult";

export class GuestViewModel{
    id=-GlobalHelper.getAppUID();
    name="";
    surname="";
    note="";

    setFromGuest(guest: Guest): void {
        this.id = guest.id;
        this.name = guest.name;
        this.surname = guest.surname;
        this.note = guest.note;
      }

    get v$(): IValidationResult{
        return {
            name:{
                required:{
                    $validator: !!this.name,
                    $message: "Imie jest wymagane!",
                }
            },
            surname:{
                required:{
                    $validator: !!this.surname,
                    $message: "Nazwisko jest wymagane!",
                }
            }
        }
    }

}