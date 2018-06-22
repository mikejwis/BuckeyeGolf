import { Component, OnInit } from '@angular/core';
import { SpinnerService } from './spinner.service';

@Component({
  selector: 'app-spinner',
  template: require('./spinner.component.html')
})
export class SpinnerComponent implements OnInit{

    subscriptionStart: any;
    subscriptionStop: any;
    visible: boolean;

    constructor(private _spinnerService:SpinnerService) {
        this.visible = false;
    }
    

    ngOnInit() {
        this.subscriptionStart = this._spinnerService.spinnerStart
            .subscribe(()=> this.spinnerStartChange(null));

        this.subscriptionStop = this._spinnerService.spinnerStop
            .subscribe(() => this.spinnerStopChange(null));
    }

    spinnerStartChange(item: any) {
        this.visible = true;
    }

    spinnerStopChange(item: any) {
        this.visible = false;
    }

    ngOnDestroy() {
        this.subscriptionStop.unsubscribe();
        this.subscriptionStart.unsubscribe();
    }

}