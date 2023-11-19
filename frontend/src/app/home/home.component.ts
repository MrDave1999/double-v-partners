import { Component } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  userName: string | null = localStorage.getItem('name');
  constructor(private router: Router) { }

  onLogout(): void
  {
    localStorage.removeItem('token');
    localStorage.removeItem('name');
    this.router.navigate(['/login']);
  }
}
