import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TerzocomponenteComponent } from './terzocomponente.component';

describe('TerzocomponenteComponent', () => {
  let component: TerzocomponenteComponent;
  let fixture: ComponentFixture<TerzocomponenteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TerzocomponenteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TerzocomponenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
