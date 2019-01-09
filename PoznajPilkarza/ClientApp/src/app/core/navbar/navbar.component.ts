import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare const SVG: any;
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(private http: HttpClient) { }

  malowanie(onHover: boolean) {
    for (let indexwhistle = 1; indexwhistle <= 3; indexwhistle++) {
      const svgele = SVG.adopt(document.getElementById(`whistle${indexwhistle}`));
      if (onHover) {
        svgele.animate(700).opacity(1).loop();
      } else {
        svgele.stop();
        svgele.opacity(0);
      }

    }
  }

  malowanie2(onHover: boolean) {

    const svgele = SVG.adopt(document.getElementById(`que-mark1`));
    if (onHover) {
      svgele.attr({
        fill: 'red'
        , stroke: 'red'
        , 'stroke-width': 1
      });
      svgele.animate(1500).rotate(360).loop();
    } else {
      svgele.stop(true);
      svgele.stroke('white');
    }
  }

  malowanie3(onHover: boolean) {
    for (let indexwhistle = 1; indexwhistle <= 4; indexwhistle++) {
      const svgele = SVG.adopt(document.getElementById(`managers${indexwhistle}`));
      if (onHover) {
        indexwhistle <= 2 ? svgele.animate(1000).opacity(1).loop() :
          svgele.animate(1000, '-', 500).opacity(1).loop();
      } else {
        svgele.stop();
        svgele.opacity(0);
      }

    }
  }

  ngOnInit() {
    this.paintingSvgIcons();
  }

  paintingSvgIcons() {
    const listIconsName: String[] = [`Whistle`, `Login`, `Managers`, `Footballer`];
    const options = { responseType: 'text' as 'text' };
    for (let indexListIconsName = 0; indexListIconsName < listIconsName.length; indexListIconsName++) {

      this.http.get(`../assets/Icons/NavIcons/${listIconsName[indexListIconsName]}.svg`, options)
        .subscribe(
          res => {
            const rawSvG = res;

            if (indexListIconsName <= 1) {
              const draw = SVG(`canvas-${listIconsName[indexListIconsName].toLowerCase()}`).size('55px', '45px');
              draw.viewbox(0, 0, 40, 30);
              draw.svg(rawSvG);
            } else {
              const draw = SVG(`canvas-${listIconsName[indexListIconsName].toLowerCase()}`).size('55px', '45px');
              draw.viewbox(0, 0, 30, 40);
              draw.svg(rawSvG);
            }
          });
    }
  }

}
