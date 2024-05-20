interface Smartphone {
    credito:number
    numeroChiamate:number
}

class User implements Smartphone {
    constructor( 
        public ricarica:number,
        public chiamata:number,
        public chiama404:number,
        public getNumeroChiamata:number,
        public azzzaraChiamate:number,
        public credito: number,
        public numeroChiamate: number
    ){}
    
}


const Topolino:User={
    ricarica: 0,
    chiamata: 0,
    chiama404: 0,
    getNumeroChiamata: 0,
    azzzaraChiamate: 0,
    credito: 0,
    numeroChiamate: 0
}

const Pippo:User={
    ricarica: 0,
    chiamata: 0,
    chiama404: 0,
    getNumeroChiamata: 0,
    azzzaraChiamate: 0,
    credito: 0,
    numeroChiamate: 0
}

const Paperino:User={
    ricarica: 0,
    chiamata: 0,
    chiama404: 0,
    getNumeroChiamata: 0,
    azzzaraChiamate: 0,
    credito: 0,
    numeroChiamate: 0
}

const Pluto:User={
    ricarica: 0,
    chiamata: 0,
    chiama404: 0,
    getNumeroChiamata: 0,
    azzzaraChiamate: 0,
    credito: 0,
    numeroChiamate: 0
}

console.log(Pluto.ricarica)