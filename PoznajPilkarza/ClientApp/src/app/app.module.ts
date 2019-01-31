import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/navbar/navbar.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MainPageComponent } from './main-page/main-page.component';
import { NavbarMainSharedService } from './shared/navbar-main-shared.service';

@NgModule({
  declarations: [
    AppComponent, NavbarComponent, MainPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  bootstrap: [AppComponent],
  providers: [NavbarMainSharedService]
})
export class AppModule { }
