import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { CoreModule } from '../core/core.module';
import { RouterModule } from '@angular/router';
import { PlayersComponent } from './players/players.component';
import { MainPageRoutingModule } from './main-page-routing.module';

@NgModule({
  declarations: [PlayersComponent],
  imports: [
    CommonModule,
    CoreModule,
    MainPageRoutingModule

  ],
  exports: [
    PlayersComponent
  ]
})
export class MainPageModule { }
