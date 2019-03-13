import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/navbar/navbar.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MainPageComponent } from './main-page/main-component/main-page.component';
import { NavbarMainSharedService } from './shared/navbar-main-shared.service';
import { MainPageRoutingModule } from './main-page/main-page-routing.module';
import { RouterModule } from '@angular/router';
import { PlayersComponent } from './main-page/players/players.component';
import { MainPageModule } from './main-page/main-page.module';
import { FormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    AppComponent, NavbarComponent, MainPageComponent, PlayersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule

  ],
  bootstrap: [AppComponent],
  providers: [NavbarMainSharedService]
})
export class AppModule { }
