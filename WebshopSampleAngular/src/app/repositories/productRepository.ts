import { Injectable } from "@angular/core";
import { Product } from "../models/Product";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class ProductRepository {
    products: Product[] = [];

    constructor(private http: HttpClient) { }

    getProducts(): Observable<Product[]> {
        return this.http.get<Product[]>('https://localhost:7129/product/GetProducts')
    }

    getProductById(id: string): Observable<Product> {
        return this.http.get<Product>(`https://localhost:7129/product/GetProductById/${id}`)
    }
}