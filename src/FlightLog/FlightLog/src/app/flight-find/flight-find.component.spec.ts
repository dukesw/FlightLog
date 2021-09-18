import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightFindComponent } from './flight-find.component';

describe('FlightFindComponent', () => {
  let component: FlightFindComponent;
  let fixture: ComponentFixture<FlightFindComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlightFindComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightFindComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
