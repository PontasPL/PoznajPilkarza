export interface IMatchDetails {
    homeTeamName: string;
    awayTeamName: string;
    matchDay: Date;
    ftHomeGoals: number;
    ftAwayGoals: number;
    htHomeGoals: number;
    htAwayGoals: number;
    leagueName: string;

    attendance: string;
    homeTeamShots: number;
    awayTeamShots: number;
    homeTeamShotsOnTarget: number;
    awayTeamShotsOnTarget: number;
    homeTeamWoodWork: number;
    awayTeamWoodWork: number;
    homeTeamCorners: number;
    awayTeamCorners: number;
    homeTeamFoulsCommitted: number;
    awayTeamFoulsCommitted: number;
    homeTeamOffsides: number;
    awayTeamOffsides: number;
    homeYellowCards: number;
    awayYellowCards: number;
    homeTeamRedCards: number;
    awayTeamRedCards: number;
}
