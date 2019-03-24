import { Component, OnInit, Input } from '@angular/core';
import * as CanvasJS from '../../../assets/Scripts/canvasjs.min.js';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.scss']
})
export class PieChartComponent implements OnInit {

  constructor() { }
  @Input() dataChart: [{}];
  data = [];
  ngOnInit() {
    const chart = new CanvasJS.Chart('chartContainer', {
      theme: 'light2',
      animationEnabled: true,
      exportEnabled: true,
      title: {
        text: 'Monthly Expense'
      },
      data: [{
        type: 'pie',
        dataPoints: this.dataChart
      }]
    });
    chart.render();
  }
}


