
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { ILeaderboard } from './leaderboard.model';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class LeaderboardService {
    //need to move this to a config file
    private _leaderboardApiUrl: string = 'http://localhost:50404/api/Leaderboard';

    constructor(private _http: HttpClient) { }

    public getLeaderboard() : Observable<ILeaderboard> {
        return this._http.get<ILeaderboard>(this._leaderboardApiUrl);

    }    
}
