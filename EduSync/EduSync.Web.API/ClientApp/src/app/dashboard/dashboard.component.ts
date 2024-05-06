import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StudentServiceService } from 'src/service/student-service.service';



@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  allStudentList:any;
  studentId:number=0;
  constructor(private student:StudentServiceService,private router:Router) { }

  ngOnInit(): void {
    this.student.getAllStudents().subscribe((res)=>{
      this.allStudentList=res;
    })
  }
  intializeId(studentid:number)
  {
    this.studentId=studentid;
  }
  deleteStudent(studentid:number)
  {
    if(studentid!=0)
    {
      this.student.deleteStudentById(studentid).subscribe((res)=>{
        if(res.responseStatusCode=="200")
        {
          alert(res.responseMessage);
            //this.toastr.success(res.responseMessage);
        }
        else{
          alert(res.responseMessage);
          //this.toastr.error(res.responseMessage);
        }
      });
    }
   
  }

  redirectToEdit(studentId)
  {
    this.router.navigate(["/edit-student"], {
      queryParams: { studentid: studentId},
      skipLocationChange: true,
    });
  }

  closeModel()
  {
    this.studentId=0;
  }


  

}
