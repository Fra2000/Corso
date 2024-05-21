import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecondocomponenteComponent } from './secondocomponente.component';

describe('SecondocomponenteComponent', () => {
  let component: SecondocomponenteComponent;
  let fixture: ComponentFixture<SecondocomponenteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SecondocomponenteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SecondocomponenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
