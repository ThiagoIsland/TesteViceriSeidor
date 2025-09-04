import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { SuperHeroiService } from '../../services/SuperHeroiService';

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
  successMessage = '';
  errorMessage = '';

  constructor(
    private formBuilder: FormBuilder,
    private superHeroiService: SuperHeroiService
  ) {
    this.heroiForm = this.formBuilder.group({
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

    const novoHeroi = {
      id: 0,
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

    this.superHeroiService.registrarSuperHeroi(novoHeroi as any).subscribe({
      next: () => {
        this.successMessage = 'Herói registrado com sucesso!';
        this.heroiForm.reset();
      },
      error: (error) => {
        this.errorMessage = 'Erro ao registrar herói: ' + (error?.error?.message || 'Erro desconhecido');
      }
    });
  }

  private clearMessages(): void {
    this.successMessage = '';
    this.errorMessage = '';
  }
}
