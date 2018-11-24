import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AccountModule } from './account/account.module';
import { TestService } from './Service/test.service';

@NgModule({
declarations: [
AppComponent,
],

imports: [
AccountModule,
BrowserModule,
AppRoutingModule,
HttpClientModule,
FormsModule
],

providers: [TestService],
bootstrap: [AppComponent]
})

export class AppModule { }
