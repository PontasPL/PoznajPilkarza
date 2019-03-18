import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { Player } from 'src/app/models/player';
import { PlayersService } from '../players/players.service';
import { INationality } from 'src/app/models/nationality';
import { NationalityService } from '../nationality.service';
import { DataSource } from '@angular/cdk/table';
import { Observable } from 'rxjs';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { FormControl } from '@angular/forms';
import { startWith, map } from 'rxjs/operators';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {
  minLength = 2;
  players: Player[];
  stateCtrl = new FormControl();
  filteredStates: Observable<Player[]>;

  constructor(private playerService: PlayersService) {
    this.filteredStates = this.stateCtrl.valueChanges
      .pipe(
        startWith(''),
        map(state => this._filterStates(state))
      );
  }

  dataSource = new MatTableDataSource(this.players);

  ngOnInit() {
    this.playerService.getPlayers().subscribe(response => {
      this.dataSource.data = response as Player[];
    });
  }


  // private cleanString(value: string): string {


  // }


  private _filterStates(value: string): Player[] {
    console.log(value);
    // let test;

    // console.log(value); // OK
    if (value && value.length > this.minLength) {


      console.log(value);
      const filterValue = value.toLowerCase();
      // this.dataz;
      return this.dataSource.data.filter(player => player.name.toLowerCase().indexOf(filterValue) === 0 ||
        player.surname.toLowerCase().indexOf(filterValue) === 0 ||
        player.name.toLowerCase().concat(' ').concat(player.surname.toLowerCase()).indexOf(filterValue) === 0);

    } else {
      return [];
    }
  }



}
