import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { ApiServiceService } from '../api-service.service';
import { User } from '../models/user.model';
import { ValidationError } from '../models/validation-error.model';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  readonly user: User = new User();
  readonly result: ValidationError = new ValidationError(); 
  constructor(private service: ApiServiceService, private router: Router) { }

  onSubmit(): void 
  {
    this.service
      .login(this.user)
      .subscribe({
        next: v => 
        {
          localStorage.setItem("name", v.data.userName);
          localStorage.setItem("token", v.data.accessToken);
          this.result.Success(v.message);
          this.user.Clear();
          this.router.navigate(['/home']);
        },
        error: v => this.result.Failure(v.error.message, v.error.errors)
      });
  }
}
