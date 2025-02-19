import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { Product } from '../../models/Product';
import { ProductRepository } from '../../repositories/productRepository';

@Component({
  selector: 'product-details',
  imports: [RouterOutlet],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})

export class DetailsComponent {
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);

  product?: Product;

  constructor(private productRepo: ProductRepository){
  }
  
  ngOnInit() {
    const productId = this.route.snapshot.paramMap.get("id");
    if (productId !== null){
      this.productRepo.getProductById(productId).subscribe(data => {
        this.product = data;
      })
    }
  }

  hasOptions():boolean {
    return (this.product?.options?.length || 0) > 1;
  }

  backToOverview() {
    this.router.navigate(['/home']);
  }
}