import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PlayersComponent } from './players/players.component';
import { SinglePlayerComponent } from './single-player/single-player.component';

const routes: Routes = [
  { path: 'search', component: PlayersComponent },
  { path: 'players/:name', component: SinglePlayerComponent }
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class MainPageRoutingModule { }
