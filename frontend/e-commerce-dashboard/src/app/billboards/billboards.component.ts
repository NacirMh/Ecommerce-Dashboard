import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BillboardService } from '../billboard.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-billboards',
  templateUrl: './billboards.component.html',
  styleUrls: ['./billboards.component.css']
})
export class BillboardsComponent {
  public myForm!: FormGroup;
  public editMode: boolean = false;
  public imageUrl: string = '';
  public billboards: any[] = [];
  private baseUrl = 'https://localhost:7086/api/Billboard';
  private editBill: any;

  public loading: boolean = false;
  constructor(private formBuilder: FormBuilder, private BillboardS: BillboardService, private http: HttpClient) { }

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
      header: ['', Validators.required],
      description: ['', Validators.required],
      image: ['']
    });

    this.getBillboards();
  }

  getBillboards() {
    this.BillboardS.getAllBillboards().subscribe(
      (res: any) => {
        this.billboards = res;
      },
      (err: any) => {
        console.error(err);
      }
    );
  }

  

  public update(id: string) {
    this.editMode = true;
    this.BillboardS.getBillboardById(id).subscribe(
      (res: any) => {
        this.editBill = res;
        this.myForm.patchValue({
          header: this.editBill.header,
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
          header: this.myForm.value.header,
          description: this.myForm.value.description,
          image: this.imageUrl,

        };

        this.http.put(`${this.baseUrl}/${this.editBill.id}`, updatedData).subscribe(
          (res: any) => {

            console.log(res);

            this.getBillboards();
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
        this.BillboardS.createBillboard(this.myForm.value).subscribe(
          (res) => {
            console.log(res);
            this.getBillboards();
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
        this.getBillboards();
      },
      (err: any) => {
        console.log(err);
      }
    );
  }
}
