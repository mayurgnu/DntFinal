import { Component, OnInit } from '@angular/core';
import { TestService } from 'src/app/Service/test.service';
import { Product } from 'src/app/Model/Model';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: [],
  providers: [TestService]
})

export class RegisterComponent implements OnInit {
  data: any;
  title = 'Simple CRUD';
  public TableData: any;
  public product = new Product;
  public obj = new Product;
  public divTableShow;
  constructor(private testService: TestService) {
    this.product = new Product();
    this.divTableShow = true;
  }

  ngOnInit() {
    this.fnGetData();
  }

  fnGetData() {
    this.testService.getData().pipe().subscribe(data => {
      this.TableData = data;
      console.log(this.data);
    });
  }

  fnAdd() {
    this.product = new Product;
    this.divTableShow = false;
  }

  fnClose() {
    this.divTableShow = true;
  }

  fnSave() {
    if (this.product.Productid === 0) {
      this.testService.postData(this.product).pipe().subscribe(data => {
        console.log(this.data);
        this.fnGetData();
        alert('Record inserted successfully.');
      });
    } else {
      this.testService.putData(this.product).pipe().subscribe(data => {
        console.log(this.data);
        this.divTableShow = true;
        this.fnGetData();
        alert('Record updated successfully.');
      });
    }
    this.divTableShow = true;
  }

  fnEdit(editObj: any) {
    this.product.Productid = editObj.productid;
    this.product.Name = editObj.name;
    this.product.Quantity = editObj.quantity;
    this.product.Price = editObj.price;
    this.divTableShow = false;
  }



  fnDelete(id: number) {
    if (confirm('Are you sure to delete?')) {
      this.testService.deleteData(id).pipe().subscribe(data => {
        console.log(this.data);
        alert('Record deleted successfully.');
        this.fnGetData();
      });
    }
  }
}
