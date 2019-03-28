import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { IPlayer } from 'src/app/models/player';
import { PlayersService } from '../players/players.service';
import { INationality } from 'src/app/models/nationality';
import { NationalityService } from '../nationality.service';
import { DataSource } from '@angular/cdk/table';
import { Observable } from 'rxjs';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { FormControl } from '@angular/forms';
import { startWith, map } from 'rxjs/operators';
import * as removeDiacritics from 'diacritics/index';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {
  minLength = 2;
  players: IPlayer[];
  stateCtrl = new FormControl();
  filteredStates: Observable<IPlayer[]>;
  removeDiacritics: any;

  constructor(private playerService: PlayersService) {
    this.filteredStates = this.stateCtrl.valueChanges
      .pipe(
        startWith(''),
        map(state => this._filterStates(state))
      );
  }

  dataSource = new MatTableDataSource(this.players);

  ngOnInit() {
    this.playerService.getPlayersNameSurname().subscribe(response => {
      this.dataSource.data = response as IPlayer[];
    });
  }



  private _filterStates(value: string): IPlayer[] {

    if (value && value.length > this.minLength) {


      const filterValue = value.toLowerCase();
      return this.dataSource.data.filter(player => removeDiacritics.remove(player.name.toLowerCase()).indexOf(filterValue) === 0 ||
        removeDiacritics.remove(player.surname.toLowerCase()).indexOf(filterValue) === 0 ||
        removeDiacritics.remove(player.name.toLowerCase()).concat(' ')
          .concat(removeDiacritics.remove(player.surname.toLowerCase())).indexOf(filterValue) === 0);

    } else {
      return [];
    }
  }



}
