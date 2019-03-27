import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import * as CanvasJS from '../../../../assets/Scripts/canvasjs.min.js';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.scss']
})
export class PieChartComponent implements AfterViewInit {
  @Input() dataChart: [{}];
  @Input() nameChart: string;
  @Input() tittleChart: string;
  constructor() { }

  ngAfterViewInit() {
    const chart = new CanvasJS.Chart(this.nameChart, {
      theme: 'dark2',
      animationEnabled: true,
      exportEnabled: true,
      title: {
        text: this.tittleChart,
        fontSize: 25
      },
      data: [{
        type: 'pie',
        showInLegend: true,
        // toolTipContent: '<b>{name}</b>: (#percent%)',
        indexLabel: '{name} - #percent%',
        dataPoints: this.dataChart
      }]
    });

    chart.render();
  }
}


