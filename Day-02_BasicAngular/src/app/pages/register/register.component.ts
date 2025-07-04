import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
username: string = '';
  email: string = '';
  password: string = '';

handleSubmit(){
  console.log('Form submitted:', {
    username: this.username,
    email: this.email,
    password: this.password
  });

  this.username = '';
  this.email = '';
  this.password = '';
}
}