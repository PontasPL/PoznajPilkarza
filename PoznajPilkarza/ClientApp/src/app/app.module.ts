import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { MainPageComponent } from './main-page/main-component/main-page.component';
import { NavbarMainSharedService } from './shared/navbar-main-shared.service';
import { PlayersComponent } from './main-page/players/players.component';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from './material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  declarations: [
    AppComponent, NavbarComponent, MainPageComponent, PlayersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MaterialModule,

  ],
  bootstrap: [AppComponent],
  providers: [NavbarMainSharedService]
})
export class AppModule { }
