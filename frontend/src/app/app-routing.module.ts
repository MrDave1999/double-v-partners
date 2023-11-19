import { NgModule, Injectable } from '@angular/core';
import { RouterModule, Routes, Router, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginComponent } from './login/login.component';
import { CreatePersonComponent } from './create-person/create-person.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { ShowPersonsComponent } from './show-persons/show-persons.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

@Injectable({ providedIn: 'root' })
export class IsLoggedInGuard {

  constructor(private router: Router) { }
  canActivate():
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    if (localStorage.getItem('token')) 
      return true;

    this.router.navigate(['/login']);
    return false;
  }
}

@Injectable({ providedIn: 'root' })
export class IsNotLoggedInGuard {

  constructor(private router: Router) { }
  canActivate():
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    if (localStorage.getItem('token')) 
    {
      this.router.navigate(['/home']);
      return false;
    }

    return true;
  }
}

const routes: Routes = [
  { path: 'login', component: LoginComponent, canActivate: [IsNotLoggedInGuard] },
  { 
    path: 'home', 
    component: HomeComponent,
    canActivate: [IsLoggedInGuard],
    children: [
      { path: 'create-user', component: CreateUserComponent },
      { path: 'create-person', component: CreatePersonComponent },
      { path: 'list', component: ShowPersonsComponent}
    ] 
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
