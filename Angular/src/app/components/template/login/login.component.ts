import { DecodeService } from './../../../services/decode/decode.service';
import { LoggedGuardService } from './../../../routeGuards/logged-guard.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private myService: LoggedGuardService,private dec: DecodeService) {}

  ngOnInit(): void {
   
  }
  
  openNotif=false;
  user=""
  pass=""

  validationInputs(){
    let userInput = this.user;
    let passInput = this.pass;


    let inputs = {
      user:userInput,
      pass:passInput
    }
    this.myService.authenticateUser(inputs);



    this.user ="";
    this.pass="";
    
    
    this.openNotif=!this.myService.isAuth;
    setTimeout(() => {
      this.openNotif=false;
    }, 3000);
    
    


    

  }


}
