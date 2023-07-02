import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CrunchService } from '../shared/services/crunch/crunch.service';
import { ApiResponse } from '../shared/models/http-response.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { BsModalService, ModalOptions } from 'ngx-bootstrap/modal'
import { CrunchedSuccessfullyComponent } from '../shared/dialogs/crunched-successfully/crunched-successfully.component';
import { CrunchedUnSuccessfulComponent } from '../shared/dialogs/crunched-un-successful/crunched-un-successful.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public crunchFile: File;

  public isNotTextFile: boolean = false;

  public constructor(
    public crunchService: CrunchService,
    private spinner: NgxSpinnerService,
    private modaleService: BsModalService
  ){}

  ngOnInit(): void {


  }

  onFileChange($event: any){

    var fileList = $event?.target.files;

    if(fileList.length > 0){

      this.crunchFile = fileList[0];

      var ext: any = /^.+\.([^.]+)$/.exec(this.crunchFile.name);
      var fileExtension: string = null ? "" : ext[1];

      if(fileExtension.toLowerCase() === 'txt'){

        this.isNotTextFile = false;

      }else{

        this.isNotTextFile = true;

      }

    }

  }

  private appendFileContent(file: File): FormData{
    
    const uploadFormData = new FormData();

    uploadFormData.append('documentFileName', file.name);
    uploadFormData.append('documentFile', file);
    uploadFormData.append('documentDescription', 'Pre-Cruch File');

    return uploadFormData;

  }

  public sendToCruncher(crunchService: CrunchService): Subscription{

    this.spinner.show();

    var crunchFileAndContents = this.appendFileContent(this.crunchFile);

    var crunchSubscription = crunchService.CrunchWord(crunchFileAndContents).subscribe({

      next: (response: ApiResponse) => {

        this.spinner.hide();

        if(response.isSuccess){

          var modalConfig: ModalOptions ={
            class: 'modal-md modal-dialog-centered',
            backdrop: 'static',
            initialState: {crunchedString: response.data}
          };

          this.modaleService.show(CrunchedSuccessfullyComponent, modalConfig);

        }else{

          var modalConfig: ModalOptions ={
            class: 'modal-md modal-dialog-centered',
            backdrop: 'static',
            initialState: {unsuccessfullMessage: response.message}
          };

          this.modaleService.show(CrunchedUnSuccessfulComponent, modalConfig);

        }

      },
      error: (error) => {

        this.spinner.hide();

      }

    });

    return crunchSubscription;

  }


}
