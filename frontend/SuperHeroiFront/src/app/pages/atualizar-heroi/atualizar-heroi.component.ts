import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { SuperHeroiService } from '../../services/SuperHeroiService';
import { SuperHeroi } from '../../interfaces/SuperHeroi.interface';

@Component({
  selector: 'app-atualizar-heroi',
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './atualizar-heroi.component.html',
  styleUrl: './atualizar-heroi.component.css'
})
export class AtualizarHeroiComponent implements OnInit {
  heroiForm: FormGroup;
  successMessage = '';
  errorMessage = '';

  constructor(
    private formBuilder: FormBuilder,
    private superHeroiService: SuperHeroiService
  ) {
    this.heroiForm = this.formBuilder.group({
      id: [0, Validators.required],
      nome: ['', Validators.required],
      nomeHeroi: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      altura: [0, Validators.required],
      peso: [0, Validators.required],
      poderesIds: ['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

  onSubmit(): void {
    if (this.heroiForm.invalid) {
      this.heroiForm.markAllAsTouched();
      return;
    }

    this.clearMessages();

    const formValues = this.heroiForm.value;
    
    const poderesIds = formValues.poderesIds
      .split(',')
      .map((id: string) => parseInt(id.trim()))
      .filter((id: number) => !isNaN(id));

    const updatedHero = {
      id: formValues.id,
      nome: formValues.nome,
      nomeHeroi: formValues.nomeHeroi,
      dataNascimento: new Date(formValues.dataNascimento),
      altura: formValues.altura,
      peso: formValues.peso,
      superPoderes: poderesIds.map((powerId: number) => ({
        id: powerId,
        superpoderNome: '',
        descricao: ''
      }))
    };

    this.superHeroiService.atualizarSuperHeroi(formValues.id, updatedHero as any).subscribe({
      next: () => {
        this.successMessage = 'Herói atualizado com sucesso!';
        this.heroiForm.reset();
      },
      error: (error) => {
        this.errorMessage = 'Erro ao atualizar herói: ' + (error?.error?.message || 'Erro desconhecido');
      }
    });
  }

  private clearMessages(): void {
    this.successMessage = '';
    this.errorMessage = '';
  }
}
