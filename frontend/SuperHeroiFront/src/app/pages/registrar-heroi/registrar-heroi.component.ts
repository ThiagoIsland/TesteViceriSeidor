import { Component, OnInit  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { SuperHeroiService } from '../../services/SuperHeroiService';
import { SuperPoderesService } from '../../services/SuperPoderesService';
import { SuperHeroi } from '../../interfaces/SuperHeroi.interface';
import { SuperPoder } from '../../interfaces/superpoder.interface';
@Component({
  selector: 'app-registrar-heroi',
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './registrar-heroi.component.html',
  styleUrl: './registrar-heroi.component.css'
})
export class RegistrarHeroiComponent implements OnInit {

  heroiForm: FormGroup;
  superpoderesDisponiveis: SuperPoder[] = [];


  constructor(
    private formBuilder: FormBuilder,
    private superHeroiService: SuperHeroiService,
    private superPoderesService: SuperPoderesService
  ) {

    this.heroiForm = this.formBuilder.group({
      nome: ['', Validators.required],
      nomeHeroi: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      altura: [0, [Validators.required, Validators.min(0.1)]],
      peso: [0, [Validators.required, Validators.min(1)]],
      poderesIds: [[], Validators.required]
    });
  }

  ngOnInit(): void {
    this.carregarSuperpoderes();
  }

  carregarSuperpoderes(): void {
    this.superPoderesService.obterTodosSuperPoderes().subscribe({
      next: (poderes) => {
        this.superpoderesDisponiveis = poderes;
      },
      error: (err) => {
      }
    });
  }

  onSubmit(): void {

    if (this.heroiForm.invalid) {
      this.heroiForm.markAllAsTouched();
      return;
    }

    const formValues = this.heroiForm.value;

    const heroisSuperpoderes = formValues.poderesIds.map((id: number) => ({
      superpoderId: id
    }));

    const novoHeroi: SuperHeroi = {
      id: 0,
      nome: formValues.nome,
      nomeHeroi: formValues.nomeHeroi,
      dataNascimento: formValues.dataNascimento,
      altura: formValues.altura,
      peso: formValues.peso,
      heroisSuperpoderes: heroisSuperpoderes
    };

    this.superHeroiService.registrarSuperHeroi(novoHeroi).subscribe({
      next: () => {
        this.heroiForm.reset();
      },
      error: (err) => {
      }
    });
  }
}
