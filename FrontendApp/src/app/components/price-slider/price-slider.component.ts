import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CustomStepDefinition, Options } from '@angular-slider/ngx-slider';
import { Router } from '@angular/router';

@Component({
  selector: 'app-price-slider',
  templateUrl: './price-slider.component.html',
  styleUrls: ['./price-slider.component.scss']
})
export class PriceSliderComponent {
  minValue: number = 100;
  maxValue: number = 2500;
  values: number[] = [
    100, 150, 200, 250, 300, 350, 400, 450, 500, 600,
    700, 800, 900, 1000, 1200, 1400, 1500, 1600, 1800,
    2000, 2500
  ];
  tickValues: CustomStepDefinition[] = [{value: 100},{value: 150},{value: 200},{value: 250},{value: 300},
    {value: 350},{value: 400},{value: 450},{value: 500},{value: 600},{value: 700},{value: 800},{value: 900},
    {value: 1000},{value: 1200},{value: 1400},{value: 1500},{value: 1600},{value: 1800},{value: 2000},{value: 2500}
  ];

  sliderOptions: Options = {
    stepsArray: this.tickValues,
    floor: 100,
    ceil: 2500,
  };

  constructor(private router: Router) {}

  updatePrices(): void {
    this.router.navigate([], {
      queryParams: {
        minPrice: this.minValue,
        maxPrice: this.maxValue
      },
      queryParamsHandling: 'merge'
    });
  }

}
