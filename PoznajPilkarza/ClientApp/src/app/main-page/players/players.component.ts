import { Component, OnInit } from '@angular/core';
import { Player } from 'src/app/models/player';
import { PlayersService } from '../players/players.service';
import { Nationality } from 'src/app/models/nationality';
import { NationalityService } from '../nationality.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnInit {

  players: Player[];
  country: 'Poland';
  countries: Nationality[] = [{ name: 'Poland' }];
  selectedCountry = this.countries[0];

  constructor(private playerService: PlayersService, private nationalityService: NationalityService) { }

  ngOnInit() {
    this.nationalityService.getNationality().subscribe(Response => {
      this.countries = Response;
    });
    this.playerService.getCars().subscribe(response => {
      this.players = response;
    });
  }
  getNewPlayers() {
    // country = 'Germany';
    this.playerService.addInfo(this.selectedCountry.name).subscribe(response => {
      this.players = response;
    });
  }
  getNationality() {
    // country = 'Germany';
    this.nationalityService.getNationality().subscribe(Response => {
      this.countries = Response;
    });

  }
}
  // sendInfo() {
  //   this.playerService.addInfo(country);
  // }


