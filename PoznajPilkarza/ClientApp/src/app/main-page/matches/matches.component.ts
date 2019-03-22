import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Match } from 'src/app/models/match';
import { League } from 'src/app/models/league';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { MatchesService } from './matches.service';
import { LeagueService } from '../league.service';
import { IMatchDetails } from 'src/app/models/matchDetails';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.scss']
})
export class MatchesComponent implements OnInit {


  constructor(private matchService: MatchesService, private leagueService: LeagueService) { }

  advancedStatistic = false;
  match: Match[];
  matchDetails: IMatchDetails[];
  leagues: League[] = [new League('LaLiga', 'Spain')];
  stateCtrl = new FormControl();

  selectedLeague = this.leagues[0].name.concat('-').concat(this.leagues[0].nationalityName);
  isLoading = true;

  displayedColumns: string[] = ['homeTeamName', 'awayTeamName', 'matchDay',
    'ftHomeGoals', 'ftAwayGoals', 'htHomeGoals', 'htAwayGoals', 'leagueName'];
  nameColumns: string[] = ['Gospodarz', 'Gość', 'Dzień',
    'GGole 90m', 'FTAwayGoals', 'HTHomeGoals', 'HTAwayGoals', 'Liga'];

  displayedColumnsDetails: string[] = ['homeTeamName', 'awayTeamName',
    'ftHomeGoals', 'ftAwayGoals', 'htHomeGoals', 'htAwayGoals', 'matchDay', 'leagueName', 'attendance', 'homeTeamShots',
    'awayTeamShots', 'homeTeamShotsOnTarget', 'awayTeamShotsOnTarget', 'homeTeamWoodWork', 'awayTeamWoodWork',
    'homeTeamCorners', 'awayTeamCorners', 'homeTeamFoulsCommitted', 'awayTeamFoulsCommitted', 'homeTeamOffsides', 'awayTeamOffsides',
    'homeYellowCards', 'awayYellowCards', 'homeTeamRedCards', 'awayTeamRedCards'];
  nameColumnsDetails: string[] = ['Gospodarz', 'Gość', 'Dzień',
    'GGole 90m', 'FTAwayGoals', 'HTHomeGoals', 'HTAwayGoals', 'Liga', 'attendance', 'homeTeamShots',
    'awayTeamShots', 'homeTeamShotsOnTarget', 'awayTeamShotsOnTarget', 'homeTeamWoodWork', 'awayTeamWoodWork',
    'homeTeamCorners', 'awayTeamCorners', 'homeTeamFoulsCommitted', 'awayTeamFoulsCommitted', 'homeTeamOffsides', 'awayTeamOffsides',
    'homeYellowCards', 'awayYellowCards', 'homeTeamRedCards', 'awayTeamRedCards'];


  dataSource = new MatTableDataSource(this.match);
  dataSourceLeagues = new MatTableDataSource(this.leagues);
  dataSourceDetails = new MatTableDataSource(this.matchDetails);


  @HostListener('window:resize') onResize() {
    if (this.advancedStatistic) {
      this.getNewMatchesWithDetails();
    } else {
      this.getNewMatches();
    }
  }
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

  advancedMatchDetailsSwitch() {
    this.advancedStatistic = !this.advancedStatistic;

    if (this.advancedStatistic) {
      this.getNewMatchesWithDetails();
    } else {
      this.getNewMatches();
    }
  }
  getNewMatchesWithDetails() {
    // this.advancedStatistic = !this.advancedStatistic;
    console.log(this.selectedLeague);
    this.isLoading = true;
    if (this.selectedLeague === 'Brak-Brak') {
      this.matchService.getMatchesWithDetails().subscribe(response => {
        this.isLoading = false;
        this.dataSourceDetails.data = response as IMatchDetails[];
      });
    } else {
      this.matchService.getMatchesWithDetailsAndLeague(this.selectedLeague)
        .subscribe(response => {
          this.isLoading = false;
          this.dataSourceDetails.data = response as IMatchDetails[];
        });
    }
  }
}


