export interface IMatchDetails {
    homeTeamName: string;
    awayTeamName: string;
    matchDay: Date;
    FTHomeGoals: number;
    FTAwayGoals: number;
    HTHomeGoals: number;
    HTAwayGoals: number;
    LeagueName: string;

    Attendance: string;
    HomeTeamShots: number;
    AwayTeamShots: number;
    HomeTeamShotsOnTarget: number;
    AwayTeamShotsOnTarget: number;
    HomeTeamWoodWork: number;
    AwayTeamWoodWork: number;
    HomeTeamCorners: number;
    AwayTeamCorners: number;
    HomeTeamFoulsCommitted: number;
    AwayTeamFoulsCommitted: number;
    HomeTeamOffsides: number;
    AwayTeamOffsides: number;
    HomeYellowCards: number;
    AwayYellowCards: number;
    HomeTeamRedCards: number;
    AwayTeamRedCards: number;
}
