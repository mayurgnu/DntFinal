import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Product } from '../Model/Model';


@Injectable({providedIn: 'root'})

export class TestService {
constructor(private httpClient: HttpClient) {
}

getData() {
return this.httpClient.get( environment.apiUrl + 'Values');
}

postData(obj: Product) {
return this.httpClient.post( environment.apiUrl + 'Values', obj);
}

putData(obj: Product) {
return this.httpClient.put( environment.apiUrl + 'Values/', obj);
}

deleteData(id: number) {
return this.httpClient.delete( environment.apiUrl + 'Values/?Productid=' + id );
}
}