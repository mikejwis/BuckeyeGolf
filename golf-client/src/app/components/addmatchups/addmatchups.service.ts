
import { Injectable } from '@angular/core';
import { Http,  Response, Headers } from '@angular/http';
import {Observable} from 'rxjs/Rx';
import { IAddMatchups } from './addmatchups.model';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class AddMatchupsService {
    //need to move this to a config file
    private _apiUrl: string = 'http://localhost:50404/api/Matchups/add';

    constructor(private _http: Http) { }

    public getAddMatchups() : Observable<IAddMatchups> {
        return this._http.get(this._apiUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public addNewMatchups(postData: any) : void {
        this._http.post(this._apiUrl, JSON.stringify(postData))
            .subscribe( data => { alert('ok'); },
                error=> { console.log(JSON.stringify(error.json())); }
            );
    }    

    private extractData(res: Response) {
        return res.json() || {};
    }
    
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}
