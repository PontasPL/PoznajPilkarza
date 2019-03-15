import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { Player } from 'src/app/models/player';
import { PlayersService } from '../players/players.service';
import { Nationality } from 'src/app/models/nationality';
import { NationalityService } from '../nationality.service';

import { Observable } from 'rxjs';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnInit, AfterViewInit {
  players: Player[];
  stateCtrl = new FormControl();
  filteredStates: Observable<Player[]>;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(private playerService: PlayersService, private nationalityService: NationalityService) {

  }
  displayedColumns: string[] = ['name', 'surname', 'nationalityName', 'positionName', 'nameLeague'];
  dataSource = new MatTableDataSource(this.players);

  ngOnInit() {

    this.playerService.getCars().subscribe(response => {
      this.dataSource.data = response as Player[];

    });


    this.dataSource.paginator = this.paginator;
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
  }









}



