import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletarHeroiComponent } from './deletar-heroi.component';

describe('DeletarHeroiComponent', () => {
  let component: DeletarHeroiComponent;
  let fixture: ComponentFixture<DeletarHeroiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeletarHeroiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeletarHeroiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
