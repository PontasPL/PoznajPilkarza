export interface ITeam {
    name: string;
    formed: number;
    nameLeague: string;
    capacityStadium: number;
    wikiLink: string;
}
export interface ITeamName {
    name: string;
}
export class NameTeam implements ITeamName {

    constructor(public name: string) { }
}
