import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlayersComponent } from './players/players.component';
import { MainPageRoutingModule } from './main-page-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { PlayersService } from './players/players.service';
import { FormsModule, FormControl, ReactiveFormsModule } from '@angular/forms';
import { NationalityService } from './nationality.service';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { SinglePlayerComponent } from './single-player/single-player.component';
import { LeagueService } from './league.service';
import { ManagersComponent } from './managers/managers.component';
import { ManagersService } from './managers/managers.service';
import { MatchesComponent } from './matches/matches.component';
import { TableValueComponent } from './table-value/table-value.component';
import { LeaguesComponent } from './leagues/leagues.component';
import { MaterialModule } from '../material.module';
import { CompareChartComponent } from './charts/compare-chart/compare-chart.component';
import { ColumnChartComponent } from './charts/column-chart/column-chart.component';
import { PieChartComponent } from './charts/pie-chart/pie-chart.component';
@NgModule({
  declarations: [PlayersComponent,
    SearchBarComponent,
    SinglePlayerComponent,
    ManagersComponent, MatchesComponent, TableValueComponent,
    LeaguesComponent, CompareChartComponent, ColumnChartComponent, PieChartComponent],
  imports: [
    CommonModule,
    MainPageRoutingModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  exports: [
    PlayersComponent, SearchBarComponent, SinglePlayerComponent, ManagersComponent, TableValueComponent
  ],
  providers: [PlayersService, NationalityService, LeagueService, ManagersService]
})
export class MainPageModule { }
