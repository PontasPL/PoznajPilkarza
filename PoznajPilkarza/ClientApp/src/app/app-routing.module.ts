import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-component/main-page.component';
import { PlayersComponent } from './main-page/players/players.component';
import { SearchBarComponent } from './main-page/search-bar/search-bar.component';
import { SinglePlayerComponent } from './main-page/single-player/single-player.component';
import { ManagersComponent } from './main-page/managers/managers.component';
import { MatchesComponent } from './main-page/matches/matches.component';
import { LeaguesComponent } from './main-page/leagues/leagues.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: MainPageComponent },
  { path: 'main', component: MainPageComponent },
  { path: 'players', component: PlayersComponent },
  { path: 'matches', component: MatchesComponent },
  { path: 'managers', component: ManagersComponent },
  { path: 'leagues', component: LeaguesComponent },
  { path: 'players/:player', component: SinglePlayerComponent },
  { path: ':player', redirectTo: '/players/:player' },

];
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
