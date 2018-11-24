import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
// path ='' => use to render the Default Component at page load.
{ path: '', component: RegisterComponent },
{ path: 'register', component: RegisterComponent }
];

@NgModule({
imports: [ CommonModule, FormsModule, RouterModule.forRoot(routes)],
declarations: [ RegisterComponent]
})

export class AccountModule { }
