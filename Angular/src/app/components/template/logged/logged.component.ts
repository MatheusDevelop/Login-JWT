import { DecodeService } from './../../../services/decode/decode.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-logged',
  templateUrl: './logged.component.html',
  styleUrls: ['./logged.component.css']
})
export class LoggedComponent implements OnInit {

  constructor(private dec:DecodeService) { }

  id=""
  nome=""
  pass=""

  ngOnInit(): void {
    let obj = this.dec.decodePayloadJWT();
    this.id=obj.sid;
    this.pass=obj.sub;
    this.nome=obj.nameid;
   
    
    

   
  }


}
