import { Component, OnInit, AfterViewInit, ViewChild, HostListener } from '@angular/core';
import { IPlayer } from 'src/app/models/player';
import { PlayersService } from '../players/players.service';
import { League } from 'src/app/models/league';
import { INationality, Nationality } from 'src/app/models/nationality';
import { NationalityService } from '../nationality.service';

import { Observable } from 'rxjs';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { FormControl } from '@angular/forms';
import { LeagueService } from '../league.service';
import { DataSource } from '@angular/cdk/table';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnInit {
  players: IPlayer[];
  countries: INationality[] = [{ name: 'Poland' }];
  leagues: League[] = [new League('Ekstraklasa', 'Poland')];
  stateCtrl = new FormControl();
  filteredStates: Observable<IPlayer[]>;
  selectedCountry = this.countries[0].name;
  selectedLeague = this.leagues[0].name.concat('-').concat(this.leagues[0].nationalityName);
  isLoading = true;
  displayedColumns: string[] = ['name', 'surname', 'dateOfBirth', 'nationalityName',
    'positionName', 'height', 'weight', 'teamName'];
  nameColumns: string[] = ['Imie', 'Nazwisko', 'Data Urodzenia', 'Państwo',
    'Pozycja', 'Wzrost', 'Waga', 'Drużyna'];

  constructor(private playerService: PlayersService, private nationalityService: NationalityService,
    private leagueService: LeagueService) { }



  dataSource = new MatTableDataSource(this.players);
  dataSourceCountries = new MatTableDataSource(this.countries);
  dataSourceLeagues = new MatTableDataSource(this.leagues);
  ngOnInit() {
    this.nationalityService.getNationalityPlayers().subscribe(response => {
      response.push({ name: 'Brak' });
      this.dataSourceCountries.data = response as INationality[];
    });
    this.leagueService.getLeagues().subscribe(response => {
      response.push({ name: 'Brak', nationalityName: 'Brak' });
      this.dataSourceLeagues.data = response as League[];
    });
    console.log(this.dataSourceLeagues.data);
    this.playerService.getPlayersWithLeagueAndCountry(this.selectedLeague, this.selectedCountry).subscribe(response => {
      this.isLoading = false;
      this.dataSource.data = response as IPlayer[];

    });

  }

  @HostListener('window:resize') onResize() {
    this.dataSource.paginator.nextPage();
    this.dataSource.paginator.previousPage();
  }

  getNewPlayers() {
    this.isLoading = true;
    if (this.selectedLeague === 'Brak-Brak' && this.selectedCountry === 'Brak') {
      this.playerService.getPlayers().subscribe(response => {
        this.isLoading = false;
        this.dataSource.data = response as IPlayer[];
      });
    } else {
      if (this.selectedLeague === 'Brak-Brak') {
        this.playerService.getPlayersWithCountry(this.selectedCountry).subscribe(response => {
          this.isLoading = false;
          this.dataSource.data = response as IPlayer[];
        });

      } else {
        if (this.selectedCountry === 'Brak') {
          this.playerService.getPlayersWithLeague(this.selectedLeague).subscribe(response => {
            this.isLoading = false;
            this.dataSource.data = response as IPlayer[];
          });
        } else {
          this.playerService.getPlayersWithLeagueAndCountry(this.selectedLeague, this.selectedCountry)
            .subscribe(response => {
              this.isLoading = false;
              this.dataSource.data = response as IPlayer[];
            });
        }
      }
    }
  }









}



