import { Component, OnInit } from '@angular/core';
import { MatchupsService } from './matchups.service';
import { IMatchups } from './matchups.model';
import { SpinnerService } from '../shared/spinner.service';

@Component({
  selector: 'app-matchups',
  template: require('./matchups.component.html')
})
export class MatchupsComponent implements OnInit {

  matchups: IMatchups = {"nextWeek":0, "players": [], "weeks": []};
  errorMessage: string;

  constructor(private _matchupService:MatchupsService, private _spinnerService:SpinnerService) { }

  ngOnInit() {
    this._spinnerService.start(); 
    this._matchupService.getMatchups()
      .subscribe(
        matchups => this.matchups = matchups,
        error => this.errorMessage = <any>error,
        ()=> this._spinnerService.stop()
      );
  }
}