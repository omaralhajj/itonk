export class Worker {
	lastName: string;
	firstName: string;
	hiringDate: string;
	areaOfExpertise: string;
	workerId: string;

	constructor(worker: Partial<Worker>) {
		Object.assign(this, worker);
	}
}
