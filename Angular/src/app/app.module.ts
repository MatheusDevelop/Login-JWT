import { LoggedGuardService } from './routeGuards/logged-guard.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SingleViewComponent } from './view/single-view/single-view.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LoginComponent } from './components/template/login/login.component';
import { LoggedComponent } from './components/template/logged/logged.component';
import { SingupComponent } from './components/template/singup/singup.component';

@NgModule({
  declarations: [
    AppComponent,
    SingleViewComponent,
    LoginComponent,
    LoggedComponent,
    SingupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FlexLayoutModule
  ],
  providers: [
    LoggedGuardService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
