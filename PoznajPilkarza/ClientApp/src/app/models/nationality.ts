export interface INationality {
    name: string;
}

export class Nationality implements INationality {
    name: string;
    constructor(name: string) {
        this.name = name;
    }
}
