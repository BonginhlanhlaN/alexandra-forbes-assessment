import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-crunched-successfully',
  templateUrl: './crunched-successfully.component.html',
  styleUrls: ['./crunched-successfully.component.css']
})
export class CrunchedSuccessfullyComponent implements OnInit{

  crunchedString: String;

  public constructor(public bsModuleRef: BsModalRef){}

  ngOnInit(): void {
    
     

  }

}
