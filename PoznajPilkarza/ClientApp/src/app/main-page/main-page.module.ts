import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { CoreModule } from '../core/core.module';
import { RouterModule } from '@angular/router';
import { PlayersComponent } from './players/players.component';
import { MainPageRoutingModule } from './main-page-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { PlayersService } from './players/players.service';
import { FormsModule, FormControl } from '@angular/forms';
import { NationalityService } from './nationality.service';
import { MatSortModule } from '@angular/material';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { SinglePlayerComponent } from './single-player/single-player.component';
import { LeagueService } from './league.service';
@NgModule({
  declarations: [PlayersComponent, SearchBarComponent, SinglePlayerComponent],
  imports: [
    CommonModule,
    CoreModule,
    MainPageRoutingModule,
    HttpClientModule,
    FormsModule,
    MatSortModule,
    FormControl,
  ],
  exports: [
    PlayersComponent, SearchBarComponent, SinglePlayerComponent
  ],
  providers: [PlayersService, NationalityService, LeagueService]
})
export class MainPageModule { }
