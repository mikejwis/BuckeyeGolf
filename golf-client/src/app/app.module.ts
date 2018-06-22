import { NgModule } from '@angular/core'
import { RouterModule } from "@angular/router";
import { rootRouterConfig } from "./app.routes";
import { AppComponent } from "./app";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";

import { HomeComponent} from './components/home/home.component';
import { LeaderboardComponent} from './components/leaderboard/leaderboard.component';
import { MatchupsComponent} from './components/matchups/matchups.component';
import { ResultsComponent} from './components/results/results.component';
import { AddMatchupsComponent} from './components/addmatchups/addmatchups.component';
import { PlayerComponent } from './components/player/player.component';
import { SpinnerComponent } from './components/shared/spinner.component';


import { AddMatchupsService } from './components/addmatchups/addmatchups.service'; 
import { ConfigService } from './components/shared/config.service';
import { MatchupsService } from './components/matchups/matchups.service'; 
import { ResultsService } from './components/results/results.service';
import { LeaderboardService } from './components/leaderboard/leaderboard.service'; 
import { PlayerService } from './components/player/player.service';
import { SpinnerService } from './components/shared/spinner.service';

import { LocationStrategy, HashLocationStrategy} from '@angular/common';

import { Store, StoreModule } from '@ngrx/store';


@NgModule({
  declarations: [ AppComponent, HomeComponent, LeaderboardComponent, MatchupsComponent, ResultsComponent, 
    AddMatchupsComponent, PlayerComponent, SpinnerComponent ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(rootRouterConfig)
  ],
  providers: [ConfigService, LeaderboardService, SpinnerService, MatchupsService, ResultsService, 
    AddMatchupsService, PlayerService],
  bootstrap: [AppComponent]
})
export class AppModule {

//Should each component provide its own service?  except for spinner service
}