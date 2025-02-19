import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { Product } from '../../models/Product';
import { ProductRepository } from '../../repositories/productRepository';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})


export class AppComponent {
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);

  title = 'Gifkikker webshop';
  subtitle = "Voor al je bier en pizza benodigdheden";
  products: Product[] = [];

  constructor(private productRepo: ProductRepository){
    productRepo.getProducts().subscribe(data => {
      this.products = data;
    })
  }

  onClick(id: string){
    this.router.navigate([`/details/${id}`]);
  }
}