import { Injectable } from '@angular/core';


@Injectable()
export class ConfigService {
    //need to move this to a config file
    private _apiUrl: string = 'http://localhost:50404/api/Player';
    
    constructor() { }

    getApiBaseUrl():string {
        return 'http://localhost:50404/api';
    }

}