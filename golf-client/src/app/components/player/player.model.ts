
export interface IPlayer {
    avgScore: number;
    handicap: number;
    losses: number;
    name: string;
    seasonHigh: number;
    seasonLow: number;
    ties: number;
    wins: number;
    totalPoints: number;
    weeklyAvgPoint: number;
    weeklyRounds: PlayerRound[];

}

export interface PlayerRound {
    weekNbr: number;
    score: number;
    points: number;
    birdies: number;
    pars: number;
    bogeys: number;
}