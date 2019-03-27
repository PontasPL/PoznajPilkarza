import { Component, OnInit, ViewChild, HostListener, Output, EventEmitter } from '@angular/core';
import { Match } from 'src/app/models/match';
import { League } from 'src/app/models/league';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { MatchesService } from './matches.service';
import { LeagueService } from '../league.service';
import { IMatchDetails } from 'src/app/models/matchDetails';
import { DataSource } from '@angular/cdk/table';
import { async } from '@angular/core/testing';
import { ITeam, NameTeam } from 'src/app/models/team';



@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.scss']
})
export class MatchesComponent implements OnInit {


  constructor(private matchService: MatchesService, private leagueService: LeagueService) { }
  dataChart = [];
  dataChartDiff = [];
  dataChartAway = [];
  dataChartDifferent = [];
  dataChartProgressPoint = [];
  dataChartSecondSecondTeam = [];
  nameChartGoals = 'Gole';
  nameChartDiffGoals = 'Roznica goli';
  nameChartPointProgress = 'ProgressPoint';
  tittleGoalChart = 'Zdobyte bramki przez poszczególne kluby w lidze';
  tittleDiffChart = 'Rożnica bramek przez poszczególne kluby w lidze';
  advancedStatistic = false;
  match: Match[];
  matchDetails: IMatchDetails[];

  leagues: League[] = [new League('LaLiga', 'Spain')];
  stateCtrl = new FormControl();
  teamsName: string[] = ['Barcelona'];
  selectedTeam = this.teamsName[0];
  selectedLeague = this.leagues[0].name.concat('-').concat(this.leagues[0].nationalityName);
  isLoading = true;

  displayedColumns: string[] = ['homeTeamName', 'awayTeamName', 'matchDay',
    'ftHomeGoals', 'ftAwayGoals', 'htHomeGoals', 'htAwayGoals', 'leagueName'];
  nameColumns: string[] = ['Gospodarz', 'Gość', 'Dzień',
    'HGFT', 'AGFT', 'HGHT', 'AGHT', 'Liga'];

  displayedColumnsDetails: string[] = ['homeTeamName', 'awayTeamName', 'matchDay',
    'ftHomeGoals', 'ftAwayGoals', 'htHomeGoals', 'htAwayGoals', 'leagueName', 'attendance', 'homeTeamShots',
    'awayTeamShots', 'homeTeamShotsOnTarget', 'awayTeamShotsOnTarget', 'homeTeamWoodWork', 'awayTeamWoodWork',
    'homeTeamCorners', 'awayTeamCorners', 'homeTeamFoulsCommitted', 'awayTeamFoulsCommitted', 'homeTeamOffsides', 'awayTeamOffsides',
    'homeYellowCards', 'awayYellowCards', 'homeTeamRedCards', 'awayTeamRedCards'];
  nameColumnsDetails: string[] = ['Gospodarz', 'Gość', 'Dzień',
    'HGFT', 'AGFT', 'HGHT', 'AGHT', 'Liga', 'ATT', 'HTS',
    'AS', 'HSOT', 'ASOT', 'HWW', 'AWW',
    'HC', 'AC', 'HF', 'AF', 'HO', 'AO',
    'HYC', 'AYC', 'HRC', 'ARC'];


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
      this.compareTwoTeamsChart();
    });
  }


  compareTwoTeamsChart() {
    this.dataChartProgressPoint = [];
    // console.log(this.dataSource.data);
    const teamA = this.selectedTeam;
    console.log(this.isLoading);
    const teamB = 'Real Madrid';

    const teamPointA = this.TeamPoints(teamA).then((name) => {
      this.dataChartProgressPoint = name;
    });
    const teamPointB = this.TeamPoints(teamB).then((name) => {
      this.dataChartSecondSecondTeam = name;
    });
    // const teamPointB = this.TeamPoints(teamB);
    // this.dataChartProgressPoint = teamPointA;
    // this.dataChartSecondSecondTeam = teamPointB;

  }


  private async TeamPoints(teamA: string) {
    const teamPoint = [];
    let teamAPoint = 0;
    let round = 0;
    const teamBPoint = 0;
    for (const match of this.dataSource.data) {
      if (match.homeTeamName === teamA && match.ftHomeGoals > match.ftAwayGoals) {
        round++;
        teamAPoint += 3;
        teamPoint.push({ x: round, y: teamAPoint, indexLabel: 'win', markerType: 'triangle', markerColor: '#6B8E23' });
      } else if (match.homeTeamName === teamA && match.ftHomeGoals < match.ftAwayGoals) {
        round++;
        teamPoint.push({ x: round, y: teamAPoint, indexLabel: 'loss', markerType: 'cross', markerColor: 'tomato' });
      } else if ((match.homeTeamName === teamA || match.awayTeamName === teamA) && match.ftHomeGoals === match.ftAwayGoals) {
        round++;
        teamAPoint += 1;
        teamPoint.push({ x: round, y: teamAPoint, indexLabel: 'draw', markerType: 'circle', markerColor: 'blue' });
      } else if (match.awayTeamName === teamA && match.ftHomeGoals < match.ftAwayGoals) {
        round++;
        teamAPoint += 3;
        teamPoint.push({ x: round, y: teamAPoint, indexLabel: 'win', markerType: 'triangle', markerColor: '#6B8E23' });
      } else if (match.awayTeamName === teamA && match.ftHomeGoals > match.ftAwayGoals) {
        round++;
        teamPoint.push({ x: round, y: teamAPoint, indexLabel: 'loss', markerType: 'cross', markerColor: 'tomato' });
      }
    }
    console.log(teamAPoint);
    return teamPoint;
  }

  getInfData() {
    this.dataChart = [];
    this.dataChartDiff = [];
    this.dataChartAway = [];
    const list: string[] = [];
    for (let index = 0; index < this.dataSource.data.length; index++) {
      const team = this.dataSource.data[index];
      list.push(team.homeTeamName);
    }
    const listName = list.filter(function (elem, index, self) {
      return index === self.indexOf(elem);
    });
    this.teamsName = listName;
    for (const teamName of listName) {
      let goals = 0;
      let lostGoals = 0;
      let awayGoals = 0;
      for (const p of this.dataSource.data) {
        if (p.homeTeamName === teamName) {
          goals += p.ftHomeGoals;
          lostGoals += p.ftAwayGoals;
        } else {
          if (p.awayTeamName === teamName) {
            goals += p.ftAwayGoals;
            lostGoals += p.ftHomeGoals;
            awayGoals += p.ftHomeGoals;
          }
        }
      }
      const diff = goals - lostGoals;
      this.dataChart.push({ y: goals, label: teamName });
      this.dataChartDiff.push({ y: diff, label: teamName });
      // this.dataChartAway.push({ y: awayGoals, label: teamName });
    }
    this.dataChart.sort((a, b) => b.y - a.y);
  }

  getNewMatches() {
    console.log(this.advancedStatistic);
    this.isLoading = true;
    if (this.selectedLeague === 'Brak-Brak') {
      this.matchService.getMatches().subscribe(response => {
        this.isLoading = false;
        this.dataSource.data = response as Match[];
        this.getInfData();
      });
    } else {
      this.matchService.getMatchesWithLeague(this.selectedLeague)
        .subscribe(response => {
          this.isLoading = false;
          this.dataSource.data = response as Match[];
          this.getInfData();
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


