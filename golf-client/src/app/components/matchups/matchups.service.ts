import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { IMatchups } from './matchups.model';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class MatchupsService {
    //need to move this to a config file
    private _apiUrl: string = 'http://localhost:50404/api/Matchups';
    
    constructor(private _http: HttpClient) { }

    getMatchups() : Observable<IMatchups> {
        return this._http.get<IMatchups>(this._apiUrl);
    }    
}