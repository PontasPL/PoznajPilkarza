import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [NavbarComponent],
  imports: [
    CommonModule

  ],
  exports: [NavbarComponent]
})
export class CoreModule { }
