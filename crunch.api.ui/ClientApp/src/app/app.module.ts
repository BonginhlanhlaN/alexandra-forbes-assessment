import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CrunchedSuccessfullyComponent } from './shared/dialogs/crunched-successfully/crunched-successfully.component';
import { CrunchedUnSuccessfulComponent } from './shared/dialogs/crunched-un-successful/crunched-un-successful.component';
import { ModalModule, BsModalService } from 'ngx-bootstrap/modal'


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CrunchedSuccessfullyComponent,
    CrunchedUnSuccessfulComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    BrowserAnimationsModule ,
    NgxSpinnerModule,
    ModalModule
   
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [BsModalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
