import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StudentServiceService } from 'src/service/student-service.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent implements OnInit {

  years: number[] = Array.from({ length: 49 }, (_, index) => 1976 + index);
  studentFormGroup: FormGroup;
  constructor(
    public _fb: FormBuilder,
    private student:StudentServiceService,
    private router: Router
  ) {

    this.studentFormGroup=this._fb.group({
      StudentName: new FormControl('',Validators.compose([Validators.required])),
      StudentEmail: new FormControl('',Validators.compose([Validators.required])),
      Enrollmentyear: new FormControl('',Validators.compose([Validators.required]))
    });
   }

  ngOnInit(): void {
  }
  onSubmitForm(data)
  {
    if(this.studentFormGroup.valid)
      {
        debugger;
        const values={
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
  clearAllFields()
  {
    this.studentFormGroup.reset();
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


