import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SuperHeroiService } from '../../services/SuperHeroiService';

@Component({
  selector: 'app-deletar-heroi',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './deletar-heroi.component.html',
  styleUrls: ['./deletar-heroi.component.css']
})
export class DeletarHeroiComponent {

  deleteForm: FormGroup;
  mensagemSucesso: string = '';
  mensagemErro: string = '';

  constructor(
    private fb: FormBuilder,
    private superHeroiService: SuperHeroiService
  ) {
    this.deleteForm = this.fb.group({
      id: [null, [Validators.required, Validators.min(1)]]
    });
  }

  onSubmit(): void {


    const idParaDeletar = this.deleteForm.value.id;

    this.superHeroiService.deletarSuperHeroi(idParaDeletar).subscribe({
        next: (resposta) => {
          this.mensagemSucesso = `Herói com ID ${idParaDeletar} foi deletado com sucesso!`;
          this.deleteForm.reset();
        },
      });
    }
  }