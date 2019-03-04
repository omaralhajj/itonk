import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerViewComponent } from './worker-view.component';

describe('WorkerViewComponent', () => {
  let component: WorkerViewComponent;
  let fixture: ComponentFixture<WorkerViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkerViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
