import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainPageComponent } from './main-page/main-component/main-page.component';
import { NavbarMainSharedService } from './shared/navbar-main-shared.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainPageModule } from './main-page/main-page.module';
import { CoreModule } from './core/core.module';



@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
  ],
  imports: [
    CoreModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MainPageModule,
  ],
  exports: [
  ],
  bootstrap: [AppComponent],
  providers: [NavbarMainSharedService]
})
export class AppModule { }
