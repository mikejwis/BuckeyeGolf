import { Component, OnInit } from '@angular/core';
import { IResults } from './results.model';
import { ResultsService} from './results.service';
import { SpinnerService } from '../shared/spinner.service'

@Component({
  selector: 'app-results',
  template: require('./results.component.html')
})
export class ResultsComponent implements OnInit {
  results: IResults[] = [];
  errorMessage: string;

  constructor(private _resultsService:ResultsService, private _spinnerService:SpinnerService) { }

  ngOnInit() {
    this._spinnerService.start(); 
    this._resultsService.getResults()
      .subscribe(
        results => this.results = results,
        error => this.errorMessage = <any>error,
        ()=> this._spinnerService.stop()
      );
  }
}