import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { CoreModule } from '../core/core.module';
import { RouterModule } from '@angular/router';
import { PlayersComponent } from './players/players.component';
import { MainPageRoutingModule } from './main-page-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { PlayersService } from './players/players.service';
import { FormsModule } from '@angular/forms';
import { NationalityService } from './nationality.service';
@NgModule({
  declarations: [PlayersComponent],
  imports: [
    CommonModule,
    CoreModule,
    MainPageRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  exports: [
    PlayersComponent
  ],
  providers: [PlayersService, NationalityService]
})
export class MainPageModule { }
