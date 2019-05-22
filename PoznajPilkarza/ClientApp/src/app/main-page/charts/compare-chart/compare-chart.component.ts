import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { SendTeamService } from '../../send-team.service';
import * as CanvasJS from '../../../../assets/Scripts/canvasjs.min.js';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-compare-chart',
  templateUrl: './compare-chart.component.html',
  styleUrls: ['./compare-chart.component.scss']
})
export class CompareChartComponent implements OnDestroy {

  // dataChart:any;
  Sub1:Subscription
  Sub2:Subscription
  Sub3:Subscription
  Sub4:Subscription

  constructor(private sendTeam: SendTeamService) {
     this.Sub1=this.sendTeam.currentFirstTeam.subscribe(team => {
  
      this.chart3.options.data[0].dataPoints = team;
      this.chart3.render();
    });
    this.Sub2 = this.sendTeam.currentSecondTeam.subscribe(team => {
  
      this.chart3.options.data[1].dataPoints = team;
      this.chart3.render();
    });
    this.Sub2 = this.sendTeam.currentFirstTeamName.subscribe(teamName => {
  
      this.chart3.options.data[0].name = teamName.toString();
      this.chart3.render();
    });

    this.Sub4 = this.sendTeam.currentSecondTeamName.subscribe(teamName => {
  
      this.chart3.options.data[1].name = teamName.toString();
      this.chart3.render();
    });
   
  }
  firstNameTeam = 'Barcelona';
  secondNameTeam = 'Real Madrid';
  chart3: any;

  @Input() dataChart: [{}];
  @Input() dataChartSecondTeam: [{}];

  ngOnInit(): void {
     this.chart3 = new CanvasJS.Chart('chartContainer', {
      theme: 'dark2', // "light1", "light2", "dark1", "dark2"
      animationEnabled: true,
      exportEnabled: true,
      title: {
        text: 'Sezon 2018/2019',
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
        name: this.firstNameTeam,
        showInLegend: true,
        markerSize: 12,
        xValueFormatString: 'pts',
        yValueFormatString: '{x}pts',
        dataPoints: this.dataChart
      },
      {
        type: 'line',
        name: this.secondNameTeam,
        showInLegend: true,
        markerSize: 12,
        xValueFormatString: 'pts',
        yValueFormatString: '{x}pts',
        dataPoints: this.dataChartSecondTeam
      }]
    });
    this.chart3.render();
    function toggleDataSeries(e) {
      if (typeof (e.dataSeries.visible) === 'undefined' || e.dataSeries.visible) {
        e.dataSeries.visible = false;
      } else {
        e.dataSeries.visible = true;
      }
      this.chart3.render();
    }
  }

  ngOnDestroy(): void {
    if(this.Sub1 && this.Sub2 && this.Sub3 && this.Sub4){

      this.Sub1.unsubscribe();
      this.Sub2.unsubscribe();
      this.Sub3.unsubscribe();
      this.Sub4.unsubscribe();
    }
  }

}
