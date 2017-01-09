
import { Injectable } from '@angular/core';
import { Http,  Response, Headers } from '@angular/http';
import {Observable} from 'rxjs/Rx';
import { ILeaderboard } from './leaderboard.model';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class LeaderboardService {
    //need to move this to a config file
    private _leaderboardApiUrl: string = 'http://localhost:50404/api/Leaderboard';

    constructor(private _http: Http) { }

    public getLeaderboard() : Observable<ILeaderboard> {
        return this._http.get(this._leaderboardApiUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }    

    private extractData(res: Response) {
        return res.json() || {};
    }
    
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}
