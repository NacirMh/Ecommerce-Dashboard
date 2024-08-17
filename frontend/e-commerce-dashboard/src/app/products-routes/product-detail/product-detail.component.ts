import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductServiceService } from 'src/app/product-service.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ToasterService } from '@coreui/angular';
import { CategoriesService } from 'src/app/categories.service';
import { TagsService } from 'src/app/tags.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  public product: any;

  public productForm: FormGroup;

  public imageUrl: string = '';

  public isopen: boolean = true;

  public loading: boolean = false;

  private apiUrl = 'https://localhost:7086/api/Product';

  public categories:any[] = [];

  public tags:any[] = [];
  
  public errorMsg:any[] = [];


  constructor(
    private productService: ProductServiceService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router,
    private http: HttpClient,
    private toastService: ToasterService,
    private catS:CategoriesService,
    private tagS:TagsService
  ) {

    this.productForm = this.fb.group({
      name: ['', Validators.required],
      price: ['', Validators.required],
      image: [''],
      description: ['', Validators.required],
      categoryId: ['', Validators.required],
      discount: ['', Validators.required],
      quantity: ['', Validators.required],
      tagId: [''],
      featured: [false]
    });

  }

  //get all cattegories
  getAllcategories() {

    this.catS.getAllCategories().subscribe(

      (data: any[]) => {

        this.categories = data;

      },
      (error) => {

        console.error(error);

      }
    );
  }

  updateNotification(){
    this.productService.getProducts().subscribe(res=>{
      //console.log(res.data.filter((product:any)=>product.quantity === 0));
      
      this.errorMsg = res.filter((product:any) => product.quantity === 0)
      .map((product:any) => ({

        name: product.name,
        id: product.id,
        image:product.image,
        errorMessage: `Error: Quantity for ${product.name} is 0. Please update the quantity.`,
        
      }));
      //console.log(this.errorMsg);
      
    })
  }

  //get all tags
  getAllTgas() {
    this.tagS.getAllTags().subscribe(
      (data: any[]) => {

        this.tags = data;

      },
      (error) => {

        console.error(error);

      }
    );
  }

  ngOnInit() {

    this.getAllTgas();

    this.getAllcategories();

    this.route.paramMap.subscribe(params => {

      const productId = params.get('id');

      if (productId) {

        this.productService.getProductById(productId).subscribe(

          (product) => {
            this.product = product;

            // Update form values with the current product data
            this.productForm.patchValue({
              name: this.product.name,
              price: this.product.price,
              image: this.product.image,
              description: this.product.description,
              category: this.product.category,
              discount: this.product.discount,
              quantity: this.product.quantity,
              tag: this.product.tag,
              featured: this.product.featured
            });

            this.imageUrl = this.product.image;

           
          },
          (error) => {

            console.log(error);

            
          }
        );
      }
    });
  }

  public openEditForm() {

    this.isopen = !this.isopen;

  }


  //delete a product by id
  public deleteProduct(id: string) {
    this.productService.deleteProductById(id).subscribe(
      (res) => {

        console.log(res);
        this.router.navigate(['/products']);
       
      },
      (err) => {
        console.log("something went wrong");
        console.log(this.product);

        console.log(err);
        
      }
    );

    this.loading = false;
  }

  onSubmit() {
    this.loading = true;
    if (this.productForm.valid) {

      this.productForm.value['image'] = this.imageUrl;

      
      this.http.put(`${this.apiUrl}/${this.product.id}`, {...this.productForm.value,updateDate:new Date()}).subscribe(
        (res) => {
          console.log(res);
          this.productForm.reset();
          this.router.navigate(['/products']);

        },
        (err) => {

          console.log(err);
      
        }
      );
    }
  }
  public  formatReadableDate(dateString:any) {
    const options:any = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit' };

    const date = new Date(dateString);

    return date.toLocaleString('en-US', options);

  }
  
  public formatPrice(price:any) {
    if (typeof price === 'string') {
     
      if (price.includes('$')) {
        
        return price.replace('$', '') + '$';
      } else {
        
        return price + '$';
      }
    } else if (typeof price === 'number') {
      
      return price.toString() + '$';
    } else {
     
      return 'N/A';
    }
  }

  onImageChange(event: any) {

    const file = event.target.files[0];

    if (file) {

      const reader = new FileReader();

      reader.onload = (e) => {
        this.imageUrl = reader.result as string;
        
      };
      reader.readAsDataURL(file);
    }
  }

  openImage() {
    const inputElement = document.getElementById('image');
    if (inputElement) {
      inputElement.click();
    }
  }
}
