import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrunchedUnSuccessfulComponent } from './crunched-un-successful.component';

describe('CrunchedUnSuccessfulComponent', () => {
  let component: CrunchedUnSuccessfulComponent;
  let fixture: ComponentFixture<CrunchedUnSuccessfulComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrunchedUnSuccessfulComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CrunchedUnSuccessfulComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
