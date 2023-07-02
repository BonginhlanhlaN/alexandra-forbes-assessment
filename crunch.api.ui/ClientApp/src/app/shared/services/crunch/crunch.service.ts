import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ApiResponse } from '../../models/http-response.model';

@Injectable({
  providedIn: 'root'
})
export class CrunchService {

  private headers = new HttpHeaders();

  constructor(private httpClient: HttpClient) { 

    this.headers.append('Content-Type', 'application/json');
    this.headers.append('Enctype', 'multipart/form-data');
    this.headers.append('Content-Type', 'application/x-www-form-urlencoded');

  }


  public CrunchWord(fileContents: any): Observable<ApiResponse>{

    return this.httpClient.post<ApiResponse>(environment.baseUrl + 'Crunch/CrunchWord', fileContents, {headers: this.headers});

  }


}
