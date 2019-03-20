import { Component, OnInit, ViewChild } from '@angular/core';
import { Match } from 'src/app/models/match';
import { League } from 'src/app/models/league';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { MatchesService } from './matches.service';
import { LeagueService } from '../league.service';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.scss']
})
export class MatchesComponent implements OnInit {

  advancedStatistic = false;
  match: Match[];
  leagues: League[] = [new League('LaLiga', 'Spain')];
  stateCtrl = new FormControl();
  filteredStates: Observable<Match[]>;
  selectedLeague = this.leagues[0].name.concat('-').concat(this.leagues[0].nationalityName);
  isLoading = true;

  displayedColumns: string[] = ['homeTeamName', 'awayTeamName', 'matchDay',
    'ftHomeGoals', 'ftAwayGoals', 'htHomeGoals', 'htAwayGoals', 'leagueName'];
  nameColumns: string[] = ['Gospodarz', 'Gość', 'Dzień',
    'GGole 90m', 'FTAwayGoals', 'HTHomeGoals', 'HTAwayGoals', 'Liga'];

  constructor(private matchService: MatchesService, private leagueService: LeagueService) { }


  dataSource = new MatTableDataSource(this.match);
  dataSourceLeagues = new MatTableDataSource(this.leagues);
  ngOnInit() {
    this.leagueService.getLeaguesMatches().subscribe(response => {
      response.push({ name: 'Brak', nationalityName: 'Brak' });
      this.dataSourceLeagues.data = response as League[];
    });
    console.log(this.dataSourceLeagues.data);
    this.matchService.getMatchesWithLeague(this.selectedLeague).subscribe(response => {
      this.isLoading = false;
      this.dataSource.data = response as Match[];

    });
  }

  changeCheckBox() {
    this.advancedStatistic = !this.advancedStatistic;
  }
  getNewMatches() {
    console.log(this.advancedStatistic);
    this.isLoading = true;
    if (this.selectedLeague === 'Brak-Brak') {
      this.matchService.getMatches().subscribe(response => {
        this.isLoading = false;
        this.dataSource.data = response as Match[];
      });
    } else {
      this.matchService.getMatchesWithLeague(this.selectedLeague)
        .subscribe(response => {
          this.isLoading = false;
          this.dataSource.data = response as Match[];
        });
    }
  }
}


