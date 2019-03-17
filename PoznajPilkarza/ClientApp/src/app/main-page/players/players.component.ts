import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { Player } from 'src/app/models/player';
import { PlayersService } from '../players/players.service';
import { League } from 'src/app/models/league';
import { Nationality } from 'src/app/models/nationality';
import { NationalityService } from '../nationality.service';

import { Observable } from 'rxjs';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { FormControl } from '@angular/forms';
import { LeagueService } from '../league.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnInit, AfterViewInit {
  players: Player[];
  countries: Nationality[] = [{ name: 'Poland' }];
  leagues: League[] = [new League('Ekstraklasa', 'Poland')];
  stateCtrl = new FormControl();
  filteredStates: Observable<Player[]>;
  selectedCountry = this.countries[0].name;
  selectedLeague = this.leagues[0];
  isLoading = true;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;


  constructor(private playerService: PlayersService, private nationalityService: NationalityService,
    private leagueService: LeagueService) { }


  displayedColumns: string[] = ['name', 'surname', 'nationalityName',
    'positionName', 'height', 'weight', 'nameTeam'];
  dataSource = new MatTableDataSource(this.players);
  dataSourceCountries = new MatTableDataSource(this.countries);
  dataSourceLeagues = new MatTableDataSource(this.leagues);
  ngOnInit() {
    this.nationalityService.getNationality().subscribe(response => {
      this.dataSourceCountries.data = response as Nationality[];
    });
    this.leagueService.getLeagues().subscribe(response => {
      this.dataSourceLeagues.data = response as League[];
    });
    this.playerService.getPlayersWithCountry(this.selectedCountry).subscribe(response => {
      this.isLoading = false;
      this.dataSource.data = response as Player[];

    });
    this.dataSource.paginator = this.paginator;
  }

  getNewPlayers() {
    // country = 'Germany';
    this.isLoading = true;
    this.playerService.getPlayersWithCountry(this.selectedCountry).subscribe(response => {
      this.isLoading = false;
      this.dataSource.data = response as Player[];
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
  }









}



