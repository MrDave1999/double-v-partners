import { Component } from '@angular/core';
import { ApiServiceService } from '../api-service.service';
import { User } from '../models/user.model';
import { ValidationError } from '../models/validation-error.model';

@Component({
  selector: 'create-user',
  templateUrl: './create-user.component.html',
  styleUrl: './create-user.component.css'
})
export class CreateUserComponent {
  readonly user: User = new User();
  readonly result: ValidationError = new ValidationError(); 
  constructor(private service: ApiServiceService) { }

  onSubmit(): void 
  {
    this.service
      .createUser(this.user)
      .subscribe({
        next: v => 
        {
          alert(v.message);
          this.user.Clear();
          this.result.Success(v.message);
        },
        error: v => this.result.Failure(v.error.message, v.error.errors)
      });
  }
}
