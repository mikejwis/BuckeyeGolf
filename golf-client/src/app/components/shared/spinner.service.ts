
import { Injectable, Output, EventEmitter } from '@angular/core';

@Injectable()
export class SpinnerService {
    @Output() spinnerStart:EventEmitter<any> = new EventEmitter();
    @Output() spinnerStop:EventEmitter<any> = new EventEmitter();

    start() {
        this.spinnerStart.emit(null);
    } 

    stop() {
        this.spinnerStop.emit(null);
    }
}