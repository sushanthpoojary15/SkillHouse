import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StudentServiceService } from 'src/service/student-service.service';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit {
  years: number[] = Array.from({ length: 49 }, (_, index) => 1976 + index);
  studentId;
  studentFormGroup: FormGroup;
  studentData;
  constructor(
    public _fb: FormBuilder,
    private student:StudentServiceService,
    private router: Router
  ) {

    let param = this.router.parseUrl(this.router.url);
    this.studentId = param.queryParams['studentid'];
    this.studentFormGroup=this._fb.group({
      StudentId:new FormControl('',Validators.compose([Validators.required])),
      StudentName: new FormControl('',Validators.compose([Validators.required])),
      StudentEmail: new FormControl('',Validators.compose([Validators.required])),
      Enrollmentyear: new FormControl('',Validators.compose([Validators.required]))
    });
   }

  ngOnInit(): void {
    this.student.getStudentById(this.studentId).subscribe((res)=>{
      if(res.responseStatusCode=="200")
        {
          const data=res.result;
          this.studentFormGroup.patchValue({
            StudentId:data.studentId,
            StudentName:data.name,
            StudentEmail:data.email,
            Enrollmentyear:data.enrollmentYear
          })
        }
        else{
          alert(res.responseMessage);   
        }
    });

  }

  onSubmitForm(data)
  {
    if(this.studentFormGroup.valid)
      {
        debugger;
        const values={
          "StudentId":data.StudentId,
          "Name":data.StudentName,
          "Email":data.StudentEmail,
          "EnrollmentYear":data.Enrollmentyear
        }
        this.student.postStudent(values).subscribe((res)=>{
          if(res.responseStatusCode=="200")
            {
              alert(res.responseMessage);
              this.router.navigate(['/dashboard']);   
            }
            else{
              alert(res.responseMessage);   
            }
        });
        
      }
    else{
     this.validateAllFields(this.studentFormGroup);
    }
  }
  backTodashboard()
  {
    this.router.navigate(['/dashboard']);
  }
  validateAllFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsDirty({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFields(control);
      }
    });

}
}
