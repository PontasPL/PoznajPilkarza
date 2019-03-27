import { Component, Input, AfterViewInit } from '@angular/core';
import * as CanvasJS from '../../../../assets/Scripts/canvasjs.min.js';

@Component({
  selector: 'app-column-chart',
  templateUrl: './column-chart.component.html',
  styleUrls: ['./column-chart.component.scss']
})
export class ColumnChartComponent implements AfterViewInit {

  constructor() { }
  @Input() dataChart: [{}];
  @Input() nameChart: string;
  @Input() tittleChart: string;
  data = [];
  ngAfterViewInit() {
    console.log(this.nameChart);
    const chart = new CanvasJS.Chart(this.nameChart, {
      theme: 'dark2',
      animationEnabled: true,
      exportEnabled: true,
      title: {
        text: this.tittleChart,
        fontSize: 25
      },
      axisX: {
        labelFontSize: 10
      },
      data: [{
        type: 'column',
        indexLabel: '{y}',
        indexLabelPlacement: 'inside',
        indexLabelOrientation: 'horizontal',
        indexLabelFontColor: 'black',
        indexLabelFontStyle: 'bold',

        // toolTipContent: '<b>{label}:</b> {y}',
        startAngle: 270,
        dataPoints: this.dataChart
      }]
    });
    chart.render();
  }

}
