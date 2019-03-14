import { Component, OnInit } from '@angular/core';
import { Player } from 'src/app/models/player';
import { PlayersService } from '../players/players.service';
import { Nationality } from 'src/app/models/nationality';
import { NationalityService } from '../nationality.service';
import { DataSource } from '@angular/cdk/table';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnInit {

  constructor(private playerService: PlayersService, private nationalityService: NationalityService) { }
  displayedColumns: string[] = ['name', 'surname', 'nationalityName', 'positionName', 'nameLeague'];
  dataSource = new PostDataSource(this.playerService);

  players: Player[];
  country: 'Poland';
  countries: Nationality[] = [{ name: 'Poland' }];
  selectedCountry = this.countries[0];


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
  test() {
    console.log(this.players);
  }

}
export class PostDataSource extends DataSource<any> {
  constructor(private dataService: PlayersService) {
    super();
  }

  connect(): Observable<Player[]> {
    return this.dataService.getCars();
  }

  disconnect() {
  }
}

  // sendInfo() {
  //   this.playerService.addInfo(country);
  // }


