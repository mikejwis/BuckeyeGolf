import { Component, OnInit } from '@angular/core';
import { LeaderboardService } from './leaderboard.service';
import { SpinnerService } from '../shared/spinner.service';
import { ILeaderboard } from './leaderboard.model';

@Component({
  selector: 'app-leaderboard',
  template: require('./leaderboard.component.html')
})
export class LeaderboardComponent implements OnInit {
  
  leaderboard: ILeaderboard = {weeksPlayed:0, firstHalfPlayerSummary: [], secondHalfPlayerSummary: []};
  errorMessage: string;
  sortBy: string;
  sortReverse: boolean;

  constructor(private _leaderboardService:LeaderboardService, private _spinnerService:SpinnerService) { 
    this.sortReverse = true;
    this.sortBy = 'totalPoints';
  }

  ngOnInit():void {
    this._spinnerService.start(); 
    this._leaderboardService.getLeaderboard()
      .subscribe(
        this.updateLeaderboard,
        function(err:Error) {this.errorMessage = err},
        ()=> this._spinnerService.stop()
      );
  }

  updateLeaderboard(leaderboardViewModel: ILeaderboard): void {
    this.leaderboard = leaderboardViewModel;
    this.leaderboard.firstHalfPlayerSummary.sort((a,b)=>b.totalPoints-a.totalPoints);  
  }
  
  sortClick(newSortBy:string):void {
      if (this.sortBy == newSortBy) this.sortReverse = !this.sortReverse;
      else {
          this.sortBy = newSortBy;
          this.sortReverse = true;
      }    
    }

  sortClickBogeys(newSortBy:string):void {
       this.sortClick(newSortBy);
       this.leaderboard.secondHalfPlayerSummary.sort(
           (a,b) => this.sortReverse ? a.bogeys - b.bogeys : b.bogeys - a.bogeys
       );
    }
    
    sortClickPars(newSortBy:string):void {
       this.sortClick(newSortBy);
       this.leaderboard.secondHalfPlayerSummary.sort(
           (a,b) => this.sortReverse ? a.pars - b.pars : b.pars - a.pars
       );
    }
    
    sortClickBirds(newSortBy:string):void {
       this.sortClick(newSortBy);
       this.leaderboard.secondHalfPlayerSummary.sort(
           (a,b) => this.sortReverse ? a.birds - b.birds : b.birds - a.birds
       );
    }
    
    sortClickScore(newSortBy:string):void {
       this.sortClick(newSortBy);
       this.leaderboard.secondHalfPlayerSummary.sort(
           (a,b) => this.sortReverse ? a.scoreAvg - b.scoreAvg : b.scoreAvg - a.scoreAvg
       );
       
    }
    
    sortClickPoints(newSortBy:string):void {
       this.sortClick(newSortBy);
       this.leaderboard.secondHalfPlayerSummary.sort(
           (a,b) => this.sortReverse ? a.totalPoints - b.totalPoints : b.totalPoints - a.totalPoints
       );
    }
    
    sortClickHandicap(newSortBy:string):void {
       this.sortClick(newSortBy); 
       this.leaderboard.secondHalfPlayerSummary.sort(
           (a,b) => this.sortReverse ? a.currentHandicap - b.currentHandicap : b.currentHandicap - a.currentHandicap
       );
    }
}
