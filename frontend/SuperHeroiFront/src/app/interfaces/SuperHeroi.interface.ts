import { SuperPoder } from "./superpoder.interface";

export interface HeroiSuperPoder {
  heroiId: number;
  superpoderId: number;
  superpoder: SuperPoder;
}

export interface SuperHeroi {
  id: number;
  nome: string;
  nomeHeroi: string;
  dataNascimento: Date;
  altura: number;
  peso: number;
  heroisSuperpoderes: HeroiSuperPoder[];
}
