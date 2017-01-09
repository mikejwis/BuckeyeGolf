

export interface IAddMatchups {
    nextWeek: number;
    players: AddMatchupPlayer[];
}

export interface AddMatchupPlayer {
    name: string;
    id: string;
}