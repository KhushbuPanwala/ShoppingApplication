import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductDetail } from './product.model';
import { Response } from '@angular/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-data',
  templateUrl: './product-data.component.html'
})


export class ProductDataComponent implements OnInit {

  public productDetails: ProductDetail[];
  baseURL: string = "";
  public productdata = new ProductDetail();
  showForm: boolean = false;
  title: string;
  constructor(public httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.baseURL = baseUrl;
  }

  ngOnInit() {
    this.getProducts();
  }

  /**
   *get product details
   */
  getProducts() {
    this.httpClient.get<ProductDetail[]>(this.baseURL + 'api/product/GetProductDetails').subscribe(result => {
      this.productDetails = result;
    }, error => console.error(error));
  }
  /**
  * Add new Product    
  */
  addProduct() {
    this.showForm = true;
    this.title = "Create";
    this.productdata = new ProductDetail();
  }

  /**
   * edit Product
   * @param id: product id
   */
  editProduct(id: number) {
    this.title = "Edit";
    this.showForm = true;
    this.httpClient.post(this.baseURL + "api/product/GetProductDetailById", id)
      .subscribe((res: ProductDetail) => {
        this.productdata = res;
      });
  }

  /**
   * Delete Product 
   * @param id: product id
   */
  deleteProduct(id: number) {
    this.httpClient.post(this.baseURL + "api/product/DeleteProduct", id)
      .subscribe((res: Response) => {
        alert('Record Deleted Successfully!!!');
        this.showForm = false;
        this.getProducts();

      });
  }

  /**
   * Save product detail
   */
  saveProduct() {
    if (this.title == "Create") {
      this.httpClient.post(this.baseURL + "api/product/AddProduct", this.productdata)
        .subscribe((res: Response) => {
          alert('Record Added Successfully!!!');
          this.showForm = false;
          this.getProducts();
        });
    }

    if (this.title == "Edit") {
      this.httpClient.post(this.baseURL + "api/product/UpdateProduct", this.productdata)
        .subscribe((res: Response) => {
          alert('Record Updated Successfully!!!');
          this.showForm = false;
          this.getProducts();
        });
    }
  }

  /**
   *Reload to list page
   * */
  cancel() {
    this.showForm = false;
    this.getProducts();
  }
}
