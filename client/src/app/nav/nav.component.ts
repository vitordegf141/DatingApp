import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any = {};

  constructor(public accountservice: AccountService) { }

  ngOnInit(): void {

  }

  login(){
    console.log(this.model);
    this.accountservice.login(this.model).subscribe(response => {
      console.log(response)
    }, error => {console.log(error); });
 }

  logout(){
    this.accountservice.logout();
  }

}
