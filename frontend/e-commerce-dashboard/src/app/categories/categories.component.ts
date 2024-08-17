import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CategoriesService } from '../categories.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
  public myForm!: FormGroup;
  public editMode: boolean = false;
  public imageUrl: string = '';
  public categories: any[] = [];
  private baseUrl = 'https://localhost:7086/api/Category';
  private editBill: any;

  public loading: boolean = false;
  constructor(private formBuilder: FormBuilder, private CategoryS: CategoriesService, private http: HttpClient) { }

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

  //price formatteur
  public formatPrice(price: any) {
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

  public formatReadableDate(dateString: any) {
    const options: any = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit' };
    const date = new Date(dateString);
    return date.toLocaleString('en-US', options);
  }

  openImage() {
    const inputElement = document.getElementById('image');
    if (inputElement) {
      inputElement.click();
    }
  }

  ngOnInit(): void {
    this.myForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      image: ['']
    });

    this.getCategories();
  }

  getCategories() {
    this.CategoryS.getAllCategories().subscribe(
      (res: any) => {
        this.categories = res;
      },
      (err: any) => {
        console.error(err);
      }
    );
  }

  

  public update(id: string) {
    this.editMode = true;
    this.CategoryS.getCategoryById(id).subscribe(
      (res: any) => {
        this.editBill = res;
        this.myForm.patchValue({
          name: this.editBill.name,
          description: this.editBill.description
        });

        this.imageUrl = this.editBill.image;


      },
      (err: any) => {
        console.error(err);
      }
    );
  }

  onSubmit() {
    if (this.myForm.valid) {
      if (this.editMode) {

        const updatedData = {
          id : this.editBill.id,
          name: this.myForm.value.name,
          description: this.myForm.value.description,
          image: this.imageUrl,

        };

        this.http.put(`${this.baseUrl}/${this.editBill.id}`, updatedData).subscribe(
          (res: any) => {

            console.log(res);

            this.getCategories();
            this.myForm.reset();
            this.editMode = false;
            this.imageUrl = "";
          },
          (err: any) => {

            console.error(err);
          }
        );
      } else {
        this.loading = true;
        this.myForm.value['image'] = this.imageUrl;
        console.log(this.myForm.value);
        this.CategoryS.createCategory(this.myForm.value).subscribe(
          (res) => {
            console.log(res);
            this.getCategories();
            this.myForm.reset();
            this.imageUrl = "";
            this.loading = false;
          },
          (err: any) => {
            console.log(err);
            this.loading = false;
          }
        );
      }
    }
  }

  public delete(id: string) {
    this.http.delete(`${this.baseUrl}/${id}`).subscribe(
      (res: any) => {
        console.log(res);
        console.log("deleting test")
        this.getCategories();
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

}
