import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieinfoComponent } from './movieinfo/movieinfo.component';
 
const routes: Routes = [
  {path: 'movieinfo',component: MovieinfoComponent},
  {path: '', component:MovieinfoComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
