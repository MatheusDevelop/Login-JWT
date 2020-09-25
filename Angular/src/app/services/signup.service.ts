import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  constructor(private router: Router) {
    
   }

  urlApi = "https://localhost:44399/api/signup"

  

  signUser(objt){
   
    let user = objt.user;
    let pass = objt.pass;

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
        setTimeout(() => {
          this.router.navigate(['/login'])          
        }, 3000);
        return
      }
      throw new Error("");             
      
    })
    .then(()=>{
      return
    })
    .catch(()=>{
      throw new Error("");
    })   
    



  }

}
