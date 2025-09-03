import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ListarHeroisComponent } from './pages/listar-herois/listar-herois.component';
import { RegistrarHeroiComponent } from './pages/registrar-heroi/registrar-heroi.component';
import { AtualizarHeroiComponent } from './pages/atualizar-heroi/atualizar-heroi.component';
import { DeletarHeroiComponent } from './pages/deletar-heroi/deletar-heroi.component';

export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'listar-herois', component: ListarHeroisComponent },
  { path: 'registrar-heroi', component: RegistrarHeroiComponent},
  { path: 'atualizar-heroi', component: AtualizarHeroiComponent},
  { path: 'deletar-heroi', component: DeletarHeroiComponent},
  { path: '**', redirectTo: '/home' }
];
