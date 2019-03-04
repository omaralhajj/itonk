import { Component, OnInit } from '@angular/core';
import { WorkerService } from './worker.service';

@Component({
	selector: 'app-worker-view',
	templateUrl: './worker-view.component.html',
	styleUrls: ['./worker-view.component.less']
})
export class WorkerViewComponent implements OnInit {

	constructor(public service: WorkerService) { }

	ngOnInit() {
		/*this.service.getWorker().subscribe((response) => {
			console.log(response);
		});*/
	}

}
