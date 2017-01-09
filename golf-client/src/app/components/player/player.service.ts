import { Injectable } from '@angular/core';
import { Http,  Response, Headers } from '@angular/http';
import {Observable} from 'rxjs/Rx';
import { IPlayer } from './player.model';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class PlayerService {
    //need to move this to a config file
    private _apiUrl: string = 'http://localhost:50404/api/Player';
    
    constructor(private _http: Http) { }

    getPlayerData(pid:string) : Observable<IPlayer> {
        return this._http.get(this._apiUrl+'/'+pid)
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