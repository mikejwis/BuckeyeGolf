import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LeaderboardComponent } from './components/leaderboard/leaderboard.component';
import { MatchupsComponent } from './components/matchups/matchups.component';
import { ResultsComponent } from './components/results/results.component';
import { AddMatchupsComponent } from './components/addmatchups/addmatchups.component';
import { PlayerComponent } from './components/player/player.component';

export const rootRouterConfig: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent},
  {path: 'leaderboard', component: LeaderboardComponent},
  {path: 'results', component: ResultsComponent},
  {path: 'matchups', component: MatchupsComponent},
  {path: 'matchups/add', component: AddMatchupsComponent},
  {path: 'player/:pid', component: PlayerComponent}
];