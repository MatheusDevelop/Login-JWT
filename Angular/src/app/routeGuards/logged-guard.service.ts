import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Router } from '@angular/router';

@Injectable()
export class LoggedGuardService implements CanActivate {


  constructor(private router: Router){

  }


  isAuth = false
  urlApi = "https://localhost:44399/api/sign"
  canActivate(){
    if(this.isAuth){
      return true
    }else{
      this.router.navigate(['/login'])
      return false;
    }
  }

  authenticateUser(userInputs){
    let user = userInputs.user;
    let pass = userInputs.pass;

    let obj = {
      Nome:user,
      Senha:pass
    }


    let myHeaders = new Headers({
      'Content-Type': 'application/json',
      
    });

    let options = {
      method:'post',
      headers:myHeaders,
      body:JSON.stringify(obj)
    }
    
    
    return fetch(this.urlApi,options)
    .then((res)=>{
      if(res.ok){
        this.isAuth=true;
        this.router.navigate(['/logged'])
        return res.json();
      }else{
        this.isAuth=false;        
      }
      
    })
    .then((data)=>{
      sessionStorage.setItem('token',data.token);
      
    })





    

  }


  


}
