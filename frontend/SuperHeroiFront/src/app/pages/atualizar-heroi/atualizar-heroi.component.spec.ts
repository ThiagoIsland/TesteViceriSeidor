import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AtualizarHeroiComponent } from './atualizar-heroi.component';

describe('AtualizarHeroiComponent', () => {
  let component: AtualizarHeroiComponent;
  let fixture: ComponentFixture<AtualizarHeroiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AtualizarHeroiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AtualizarHeroiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
