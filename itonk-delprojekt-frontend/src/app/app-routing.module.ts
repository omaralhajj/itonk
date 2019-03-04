import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkerViewComponent } from './worker-view/worker-view.component';

const routes: Routes = [
	{
		path: '',
		redirectTo: '/worker',
		pathMatch: 'full'
	},
	{
		path: 'worker',
		component: WorkerViewComponent
	}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
