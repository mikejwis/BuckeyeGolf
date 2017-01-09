import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { AddMatchupsService } from './addmatchups.service';
import { IAddMatchups } from './addmatchups.model';
import { SpinnerService } from '../shared/spinner.service';

//import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-addmatchups',
  template: require('./addmatchups.component.html')
})
export class AddMatchupsComponent implements OnInit {

  addMatchups: IAddMatchups = {"nextWeek":0, "players": []};
  errorMessage: string;
  submitted:boolean = false;

  constructor(private _addmatchupService:AddMatchupsService, private _spinnerService:SpinnerService) { }

  ngOnInit() {
    this._spinnerService.start(); 
    this._addmatchupService.getAddMatchups()
      .subscribe(
        addMatchups => this.updateAddMatchup(addMatchups),
        error => this.errorMessage = <any>error,
        ()=> this._spinnerService.stop()
      );
  }

  updateAddMatchup(matchupViewModel:IAddMatchups):void {
    this.addMatchups = matchupViewModel;
//    this.model = this.addMatchups;

  }

  add(form:NgForm):void {
    this.submitted = true;

  }
}