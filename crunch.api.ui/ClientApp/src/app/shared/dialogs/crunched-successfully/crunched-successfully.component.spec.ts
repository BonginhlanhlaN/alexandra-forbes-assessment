import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrunchedSuccessfullyComponent } from './crunched-successfully.component';

describe('CrunchedSuccessfullyComponent', () => {
  let component: CrunchedSuccessfullyComponent;
  let fixture: ComponentFixture<CrunchedSuccessfullyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrunchedSuccessfullyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CrunchedSuccessfullyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
