import { Component, inject } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { Product } from '../../models/Product';
import { ProductRepository } from '../../repositories/productRepository';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})


export class HomeComponent {
  private readonly router = inject(Router);
  
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