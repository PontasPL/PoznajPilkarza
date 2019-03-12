import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-component/main-page.component';
import { PlayersComponent } from './main-page/players/players.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: MainPageComponent },
  { path: 'main', component: MainPageComponent },
  { path: 'players', component: PlayersComponent },
  { path: 'matches', component: PlayersComponent },
  { path: 'managers', component: PlayersComponent },
  { path: 'login', component: PlayersComponent },
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
