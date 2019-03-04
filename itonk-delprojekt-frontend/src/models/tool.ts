export class Tool {
	foundInToolbox: string;
	aquired: string;
	manufacturer: string;
	id: string;
	model: string;
	serialNumber: string;
	type: string;

	constructor(tool: Partial<Tool>) {
		Object.assign(this, tool);
	}
}
