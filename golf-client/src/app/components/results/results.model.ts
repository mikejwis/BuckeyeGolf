
export interface IResults {
    weekNbr: number;
    playerRounds: ResultRounds[];
}

export interface ResultRounds{
    name: string;
    playerId: string;
    totalScore: number;
    totalPoints: number;
    birdies: number;
    pars: number;
    bogeys: number;
}