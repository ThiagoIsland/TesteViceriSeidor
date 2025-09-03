import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SuperHeroiService } from '../../services/SuperHeroiService';
import { SuperHeroi } from '../../interfaces/SuperHeroi.interface';

@Component({
  selector: 'app-listar-herois',
  imports: [CommonModule],
  templateUrl: './listar-herois.component.html',
  styleUrl: './listar-herois.component.css'
})
export class ListarHeroisComponent implements OnInit {
  herois: SuperHeroi[] = [];

  constructor(private superHeroiService: SuperHeroiService) {}

  ngOnInit(): void {
    this.carregarHerois();
  }

  carregarHerois(): void {
    this.superHeroiService.obterTodosSuperHerois().subscribe({
      next: (herois) => {
        console.log('Heróis carregados:', herois);
        this.herois = herois;
      }
    });
  }
}
