import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PlayersService } from '../players/players.service';
import { IPlayer, Player } from 'src/app/models/player';

@Component({
  selector: 'app-single-player',
  templateUrl: './single-player.component.html',
  styleUrls: ['./single-player.component.scss']
})
export class SinglePlayerComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute,
    private playerService: PlayersService) { }
  playerNameFromRoute: string;
  player: IPlayer;
  loading = true;

  ngOnInit() {
    console.log('test');
    this.activatedRoute.params.subscribe(params => {
      this.playerService.getPlayer(params['player']).subscribe(response => {
        this.player = response as IPlayer;
        this.loading = false;
      });
      // console.log('TEST:' + this.playerNameFromRoute);
    });

  }

}
