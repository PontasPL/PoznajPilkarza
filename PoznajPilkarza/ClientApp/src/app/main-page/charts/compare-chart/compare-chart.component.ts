import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import * as CanvasJS from '../../../../assets/Scripts/canvasjs.min.js';

@Component({
  selector: 'app-compare-chart',
  templateUrl: './compare-chart.component.html',
  styleUrls: ['./compare-chart.component.scss']
})
export class CompareChartComponent implements AfterViewInit {

  constructor() { }

  @Input() dataChart: [{}];
  @Input() dataChartSecondTeam: [{}];
  // @Input() nameChart: string;
  data = [];
  ngAfterViewInit() {
    console.log(this.dataChart);
    const chart = new CanvasJS.Chart('chartContainer', {
      theme: 'dark2', // "light1", "light2", "dark1", "dark2"
      animationEnabled: true,
      exportEnabled: true,
      title: {
        text: 'FC Barcelona 2019',
        fontSize: 25
      },
      axisX: {
        interval: 1,
      },
      legend: {
        cursor: 'pointer',
        itemclick: toggleDataSeries
      },
      data: [{
        type: 'line',
        name: 'Barcelona',
        showInLegend: true,
        markerSize: 12,
        xValueFormatString: 'pts',
        yValueFormatString: '{x}pts',
        dataPoints: this.dataChart
      },
      {
        type: 'line',
        name: 'Real',
        showInLegend: true,
        markerSize: 12,
        xValueFormatString: 'pts',
        yValueFormatString: '{x}pts',
        dataPoints: this.dataChartSecondTeam
      }]
    });
    chart.render();
    function toggleDataSeries(e) {
      if (typeof (e.dataSeries.visible) === 'undefined' || e.dataSeries.visible) {
        e.dataSeries.visible = false;
      } else {
        e.dataSeries.visible = true;
      }
      chart.render();
    }


  }

}
