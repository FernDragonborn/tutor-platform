import { Component } from '@angular/core';
import { Options } from '@angular-slider/ngx-slider';
import { PriceService } from 'src/app/services/price.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-price-slider',
  templateUrl: './price-slider.component.html',
  styleUrls: ['./price-slider.component.scss']
})
export class PriceSliderComponent {
  minValue: number = 100;
  maxValue: number = 2500;
  sliderOptions: Options = {
    floor: 100,
    ceil: 2500,
    step: 50
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
