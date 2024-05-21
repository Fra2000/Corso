import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrimocomponenteComponent } from './primocomponente.component';

describe('PrimocomponenteComponent', () => {
  let component: PrimocomponenteComponent;
  let fixture: ComponentFixture<PrimocomponenteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PrimocomponenteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PrimocomponenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
