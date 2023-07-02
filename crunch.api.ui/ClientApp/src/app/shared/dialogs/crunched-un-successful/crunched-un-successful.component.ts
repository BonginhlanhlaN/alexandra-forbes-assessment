import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-crunched-un-successful',
  templateUrl: './crunched-un-successful.component.html',
  styleUrls: ['./crunched-un-successful.component.css']
})
export class CrunchedUnSuccessfulComponent implements OnInit {

  unsuccessfullMessage: String;

  public constructor(public bsModuleRef: BsModalRef){}

  ngOnInit(): void {
    
     

  }

}
