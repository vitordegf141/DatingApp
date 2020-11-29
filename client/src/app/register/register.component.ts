import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Toast, ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister = new EventEmitter();
  model:any ={};

  constructor(private accountservice : AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  register(){
    this.accountservice.Register(this.model).subscribe(
      response =>{
        this.cancel();
      },
      err =>{
        console.log(err);
        this.toastr.error(err.error); 
      })
  }
  cancel(){
    this.cancelRegister.emit(false);
  }

}
