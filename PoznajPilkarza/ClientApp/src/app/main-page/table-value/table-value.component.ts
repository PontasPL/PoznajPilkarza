import { Component, OnInit, Input, ViewChild, AfterViewInit, AfterContentInit, HostListener } from '@angular/core';
import { DataSource } from '@angular/cdk/table';
import { Player } from 'src/app/models/player';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';

@Component({
  selector: 'app-table-value',
  templateUrl: './table-value.component.html',
  styleUrls: ['./table-value.component.scss']
})
export class TableValueComponent implements OnInit, AfterContentInit {
  @Input() dataSource: MatTableDataSource<any>;
  @Input() loading: boolean;
  @Input() displayedColumns: string[];
  @Input() nameColumns: string[];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  bigTable = false;
  player: Player;
  constructor() { }
  ngOnInit() {
    if (this.nameColumns.length > 10) {
      this.bigTable = true;
    }
    this.dataSource.paginator = this.paginator;
  }

  ngAfterContentInit(): void {
    this.dataSource.sortingDataAccessor = (item, property) => {
      switch (property) {
        case 'matchDay': {
          const newDate = new Date(item.matchDay);
          return newDate;
        }
        default: return item[property];
      }
    };
    this.dataSource.sort = this.sort;
  }


}
