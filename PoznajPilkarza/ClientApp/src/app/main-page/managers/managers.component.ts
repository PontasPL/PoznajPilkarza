import { Component, OnInit, ViewChild, AfterViewInit, HostListener } from '@angular/core';
import { Manager } from 'src/app/models/manager';
import { INationality } from 'src/app/models/nationality';
import { League } from 'src/app/models/league';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { ManagersService } from './managers.service';
import { NationalityService } from '../nationality.service';
import { LeagueService } from '../league.service';

@Component({
  selector: 'app-managers',
  templateUrl: './managers.component.html',
  styleUrls: ['./managers.component.scss']
})
export class ManagersComponent implements OnInit {
  managers: Manager[];
  countryDataCharts: any[];
  countryManagerChart = 'countryManagerChart';
  tittleCountry = 'Ilość trenerów danego państwa w lidze';
  countries: INationality[] = [{ name: 'Poland' }];
  leagues: League[] = [new League('Ekstraklasa', 'Poland')];
  stateCtrl = new FormControl();
  filteredStates: Observable<Manager[]>;
  selectedCountry = this.countries[0].name;
  selectedLeague = this.leagues[0].name.concat('-').concat(this.leagues[0].nationalityName);
  isLoading = true;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;




  displayedColumns: string[] = ['name', 'surname', 'nationalityName',
    'teamName'];
  nameColumns: string[] = ['Imie', 'Nazwisko', 'Państwo',
    'Drużyna'];

  constructor(private managerService: ManagersService, private nationalityService: NationalityService,
    private leagueService: LeagueService) { }




  dataSource = new MatTableDataSource(this.managers);
  dataSourceCountries = new MatTableDataSource(this.countries);
  dataSourceLeagues = new MatTableDataSource(this.leagues);
  ngOnInit() {
    this.nationalityService.getNationalityManagers().subscribe(response => {
      response.push({ name: 'Brak' });
      this.dataSourceCountries.data = response as INationality[];
    });
    this.leagueService.getLeagues().subscribe(response => {
      response.push({ name: 'Brak', nationalityName: 'Brak' });
      this.dataSourceLeagues.data = response as League[];
    });
    console.log(this.dataSourceLeagues.data);
    this.managerService.getPlayersWithLeagueAndCountry(this.selectedLeague, this.selectedCountry).subscribe(response => {
      this.isLoading = false;
      this.dataSource.data = response as Manager[];
      this.GetCountryForChart();
    });
  }

  @HostListener('window:resize') onResize() {
    this.dataSource.paginator.nextPage();
    this.dataSource.paginator.previousPage();
  }

  GetCountryForChart() {
    this.countryDataCharts = [];
    const dataCountry = [];
    const regex = /\d{4}/g;
    for (const manager of this.dataSource.data) {
      // console.log(player.dateOfBirth.toString().match(regex)[0]);
      if (manager.nationalityName !== 'No data') {
        dataCountry.push(manager.nationalityName);
      }
    }
    const distinctCountry = dataCountry.filter(function (elem, index, self) {
      return index === self.indexOf(elem);
    });
    for (const country of distinctCountry) {
      let countryCounter = 0;
      for (const player of this.dataSource.data) {
        if (country === player.nationalityName) {
          countryCounter++;
        }
      }
      this.countryDataCharts.push({ y: countryCounter, name: country });
    }
  }

  getNewManagers() {
    this.isLoading = true;
    if (this.selectedLeague === 'Brak-Brak' && this.selectedCountry === 'Brak') {
      this.managerService.getPlayers().subscribe(response => {
        this.dataSource.data = response as Manager[];
        this.GetCountryForChart();
        this.isLoading = false;
      });
    } else {
      if (this.selectedLeague === 'Brak-Brak') {
        this.managerService.getPlayersWithCountry(this.selectedCountry).subscribe(response => {
          this.dataSource.data = response as Manager[];
          this.GetCountryForChart();
          this.isLoading = false;
        });

      } else {
        if (this.selectedCountry === 'Brak') {
          this.managerService.getPlayersWithLeague(this.selectedLeague).subscribe(response => {
            this.dataSource.data = response as Manager[];
            this.GetCountryForChart();
            this.isLoading = false;
          });
        } else {
          this.managerService.getPlayersWithLeagueAndCountry(this.selectedLeague, this.selectedCountry)
            .subscribe(response => {
              this.dataSource.data = response as Manager[];
              this.GetCountryForChart();
              this.isLoading = false;
            });
        }
      }
    }
  }




}
