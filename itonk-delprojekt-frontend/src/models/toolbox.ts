export class Toolbox {
	aquired: string;
	ownedBy: string;
	manufacturer: string;
	color: string;
	id: string;
	model: string;
	serialnNumber: string;

	constructor(toolbox: Partial<Toolbox>) {
		Object.assign(this, toolbox);
	}
}
