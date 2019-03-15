import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-component/main-page.component';
import { PlayersComponent } from './main-page/players/players.component';
import { SearchBarComponent } from './main-page/search-bar/search-bar.component';
import { SinglePlayerComponent } from './main-page/single-player/single-player.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: MainPageComponent },
  { path: 'main', component: MainPageComponent },
  { path: 'players', component: PlayersComponent },
  { path: 'matches', component: SearchBarComponent },
  { path: 'managers', component: PlayersComponent },
  { path: 'login', component: PlayersComponent },
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
