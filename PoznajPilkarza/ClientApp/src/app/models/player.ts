export interface IPlayer {
    name: string;
    surname: string;
    shirtNumber: number;
    nationalityName: string;
    dateOfBirth: Date;
    positionName: string;
    height: number;
    weight: number;
    teamName: string;
    leagueName: string;
    nationalLeagueName: string;
    flagNational: string;
    wikiLink: string;
    description: string;
}
export class Player implements IPlayer {
    name: string; surname: string;
    shirtNumber: number;
    nationalityName: string;
    dateOfBirth: Date;
    positionName: string;
    height: number;
    weight: number;
    teamName: string;
    leagueName: string;
    nationalLeagueName: string;
    flagNational: string;
    wikiLink: string;
    description: string;
    /**
     *
     */
    constructor(name: string) {
        this.name = name;

    }

}
