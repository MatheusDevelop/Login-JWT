import { SignupService } from './../../../services/signup.service';
import { Component, OnChanges, OnInit } from '@angular/core';

@Component({
  selector: 'app-singup',
  templateUrl: './singup.component.html',
  styleUrls: ['./singup.component.css']
})
export class SingupComponent implements OnInit {

  constructor(private myService:SignupService) { }

  ngOnInit(): void {
  }

  openNotifError=false;
  openNotifSuccess=false;
  user=""
  pass=""


  validationInputs(){
   
    let userInput = this.user;
    let passInput = this.pass;


    let inputs = {
      user:userInput,
      pass:passInput
    }

   

    this.myService.signUser(inputs).then(()=>{
      this.openNotifSuccess=true;
      setTimeout(() => {
        this.openNotifSuccess=false;
      }, 3000);
    }).catch(()=>{
      this.openNotifError=true;
      setTimeout(() => {
        this.openNotifError=false;
      }, 3000);
    });   
    
    this.user ="";
    this.pass="";
   
  }



}
