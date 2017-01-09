import { Component, OnInit, OnDestroy  } from '@angular/core';
import { PlayerService } from './player.service';
import { IPlayer } from './player.model';
import { SpinnerService } from '../shared/spinner.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-player',
  template: require('./player.component.html')
})
export class PlayerComponent implements OnInit, OnDestroy  {

  player: IPlayer = {avgScore:0, losses:0, ties:0, wins:0, handicap:0,
    name:"", seasonLow:0, seasonHigh:0, totalPoints:0, weeklyAvgPoint: 0,
    weeklyRounds:[]};
  errorMessage: string;
  sub: any;
  playerId: string;

  constructor(private _route: ActivatedRoute, private _playerService:PlayerService, private _spinnerService:SpinnerService) { }

  ngOnInit() {

    this.sub = this._route.params.subscribe(params => {
       this.playerId = params['pid'];

        this._spinnerService.start(); 
        this._playerService.getPlayerData(this.playerId)
        .subscribe(
            player => this.updatePlayer(player),
            error => this.errorMessage = <any>error,
            ()=> this._spinnerService.stop()
        );
    });
    
  }

  updatePlayer(playerViewModel:IPlayer):void {
      this.player=playerViewModel;
      this.player.weeklyRounds.sort((a,b)=>a.weekNbr-b.weekNbr);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}