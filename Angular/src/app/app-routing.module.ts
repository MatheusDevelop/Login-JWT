import { SingupComponent } from './components/template/singup/singup.component';
import { LoggedComponent } from './components/template/logged/logged.component';
import { LoginComponent } from './components/template/login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoggedGuardService } from './routeGuards/logged-guard.service';

const routes: Routes = [
  {path:"login",component:LoginComponent},
  { path:"logged",
  component:LoggedComponent,
  canActivate:[LoggedGuardService]
},
{path:"singup",component:SingupComponent},
{path:"",component:LoginComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
