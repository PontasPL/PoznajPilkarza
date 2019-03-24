import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Match } from 'src/app/models/match';
import { League } from 'src/app/models/league';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { MatchesService } from './matches.service';
import { LeagueService } from '../league.service';
import { IMatchDetails } from 'src/app/models/matchDetails';
import { DataSource } from '@angular/cdk/table';



@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.scss']
})
export class MatchesComponent implements OnInit {


  constructor(private matchService: MatchesService, private leagueService: LeagueService) { }
  dataChart = [];
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

  displayedColumnsDetails: string[] = ['homeTeamName', 'awayTeamName', 'matchDay',
    'ftHomeGoals', 'ftAwayGoals', 'htHomeGoals', 'htAwayGoals', 'leagueName', 'attendance', 'homeTeamShots',
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
    this.dataSource.paginator.nextPage();
    this.dataSource.paginator.previousPage();
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
      this.getInfData();
    });
  }

  getInfData() {
    const list: string[] = [];
    for (let index = 0; index < this.dataSource.data.length; index++) {
      const a = this.dataSource.data[index];
      list.push(a.homeTeamName);
    }
    const listname = list.filter(function (elem, index, self) {
      return index === self.indexOf(elem);
    });
    for (const b of listname) {
      let test = 0;
      for (const p of this.dataSource.data) {
        if (p.homeTeamName === b) {
          test += p.ftHomeGoals;
        } else {
          if (p.awayTeamName === b) {
            test += p.ftAwayGoals;
          }
        }
      }
      this.dataChart.push({ y: test, name: b });
    }
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


