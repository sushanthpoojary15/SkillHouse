import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AddStudentComponent } from './add-student/add-student.component';
import { EditStudentComponent } from './edit-student/edit-student.component';
import { StudentStasticsComponent } from './student-stastics/student-stastics.component';

const routes: Routes = [
  {path:'dashboard', component: DashboardComponent},
  {path:'add-student',component:AddStudentComponent},
  {path:'edit-student',component:EditStudentComponent},
  {path:'student-stastics',component:StudentStasticsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
