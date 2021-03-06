import { Component, OnInit, HostListener } from '@angular/core';
import { LeagueService } from '../league.service';
import { TeamsService } from './teams.service';
import { ITeam } from 'src/app/models/team';
import { MatTableDataSource } from '@angular/material';
import { League } from 'src/app/models/league';

@Component({
  selector: 'app-leagues',
  templateUrl: './leagues.component.html',
  styleUrls: ['./leagues.component.scss']
})
export class LeaguesComponent implements OnInit {


  constructor(private teamService: TeamsService, private leagueService: LeagueService) { }

  isLoading = true;
  advancedStatistic = false;
  team: ITeam[];
  leagues: League[] = [new League('LaLiga', 'Spain')];
  dataSource = new MatTableDataSource(this.team);
  dataSourceLeagues = new MatTableDataSource(this.leagues);
  selectedLeague = this.leagues[0].name.concat('-').concat(this.leagues[0].nationalityName);

  displayedColumns: string[] = ['name', 'formed', 'nameLeague',
    'nameStadium', 'capacityStadium'];
  nameColumns: string[] = ['Nazwa', 'Rok Założenia', 'Nazwa Ligi',
    'Nazwa Stadionu', 'Pojemność stadionu'];



  @HostListener('window:resize') onResize() {
    this.dataSource.paginator.nextPage();
    this.dataSource.paginator.previousPage();
  }
  ngOnInit() {
    this.leagueService.getLeagues().subscribe(response => {
      response.push({ name: 'Brak', nationalityName: 'Brak' });
      this.dataSourceLeagues.data = response as League[];
    });
    this.teamService.GetTeamInLeague(this.selectedLeague).subscribe(response => {
      this.isLoading = false;
      this.dataSource.data = response as ITeam[];

    });
  }


  GetNewTeams() {
    this.isLoading = true;
    if (this.selectedLeague === 'Brak-Brak') {
      this.teamService.GetTeams().subscribe(response => {
        this.isLoading = false;
        this.dataSource.data = response as ITeam[];
      });
    } else {
      this.teamService.GetTeamInLeague(this.selectedLeague)
        .subscribe(response => {
          this.isLoading = false;
          this.dataSource.data = response as ITeam[];
        });
    }
  }



}
