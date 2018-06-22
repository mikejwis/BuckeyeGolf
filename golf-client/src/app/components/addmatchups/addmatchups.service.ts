
import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import { IAddMatchups } from './addmatchups.model';

@Injectable()
export class AddMatchupsService {
    //need to move this to a config file
    private _apiUrl: string = 'http://localhost:50404/api/Matchups/add';

    constructor(private _http: HttpClient) { }

    public getAddMatchups() : Observable<IAddMatchups> {
        return this._http.get<IAddMatchups>(this._apiUrl);
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
