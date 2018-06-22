import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { IPlayer } from './player.model';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class PlayerService {
    //need to move this to a config file
    private _apiUrl: string = 'http://localhost:50404/api/Player';
    
    constructor(private _http: HttpClient) { }

    getPlayerData(pid:string) : Observable<IPlayer> {
        return this._http.get<IPlayer>(this._apiUrl+'/'+pid);
    }    
}