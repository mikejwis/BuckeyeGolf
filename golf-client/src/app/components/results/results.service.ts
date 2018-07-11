import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { IResults } from './results.model';

@Injectable()
export class ResultsService {
    //need to move this to a config file
    private _apiUrl: string = 'http://localhost:50404/api/Results';
    
    constructor(private _http: HttpClient) { }

    getResults() : Observable<IResults[]> {
        return this._http.get<IResults[]>(this._apiUrl);
    }    
}