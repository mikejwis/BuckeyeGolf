
export interface IMatchups {
    nextWeek: number;
    players: MatchupPlayer[];
    weeks: MatchupWeek[];
}

export interface MatchupWeek {
    weekNbr: number;
    matchups: Matchup[];
}

export interface Matchup {
    player1Name: string;
    player2Name: string;
    player1Handicap: number;
    player2Handicap: number;
}

export interface MatchupPlayer {
    name: string;
    id:string;
}
