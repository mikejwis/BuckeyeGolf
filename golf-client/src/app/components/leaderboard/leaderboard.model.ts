
export interface ILeaderboard {
    firstHalfPlayerSummary: PlayerLeaderboardViewModel[];
    secondHalfPlayerSummary: PlayerLeaderboardViewModel[];
    weeksPlayed: number;
}

export interface PlayerLeaderboardViewModel {
    birds: number;
    bogeys: number;
    currentHandicap: number;
    name: string;
    pars: number;
    scoreAvg: number;
    totalPoints: number;
}