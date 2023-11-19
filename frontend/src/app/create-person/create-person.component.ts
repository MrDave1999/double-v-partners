import { Component } from '@angular/core';
import { ApiServiceService } from '../api-service.service';
import { Person } from '../models/person.model';
import { ValidationError } from '../models/validation-error.model';

@Component({
  selector: 'create-person',
  templateUrl: './create-person.component.html',
  styleUrl: './create-person.component.css'
})
export class CreatePersonComponent {
  readonly person: Person = new Person();
  readonly result: ValidationError = new ValidationError(); 
  constructor(private service: ApiServiceService) { }

  onSubmit(): void 
  {
    this.service
      .createPerson(this.person)
      .subscribe({
        next: v => 
        {
          alert(v.message);
          this.person.Clear();
          this.result.Success(v.message);
        },
        error: v => this.result.Failure(v.error.message, v.error.errors)
      });
  }
}
