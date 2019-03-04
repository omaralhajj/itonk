import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
	providedIn: 'root'
})
export class WorkerService {
	url: string;

	constructor(public http: HttpClient) { }

	getWorker(): Observable<any> {
		return this.http.get<any>(this.url);
	}

	getToolbox(): Observable<any> {
		return this.http.get<any>(this.url);
	}

	getTool(): Observable<any> {
		return this.http.get<any>(this.url);
	}
}
