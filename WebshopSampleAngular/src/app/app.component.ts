import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})


export class AppComponent {
  title = 'WebshopSampleAngular';
  products: Product[] = [];

  constructor(http: HttpClient) {
    http.get<Product[]>('https://localhost:7129/product').subscribe(data => {
      this.products = data;
    });
  }

}

export interface Product {
  name: string,
  description: string,
  options: string[],
  image: string
}