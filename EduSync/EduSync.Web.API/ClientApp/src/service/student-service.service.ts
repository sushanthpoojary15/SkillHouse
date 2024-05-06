import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { AppSettings } from 'src/app/common';
@Injectable({
  providedIn: 'root'
})
export class StudentServiceService {

  constructor(private httpClient: HttpClient) { 

  }
  getAllStudents()
  {
    return this.httpClient.get<any>(
      AppSettings.URLs.Student.GetAllStudents,  
    );
  }

  deleteStudentById(id:number)
  {
    return this.httpClient.delete<any>(AppSettings.URLs.Student.DeleteStudentById + id);
  }

  postStudent(value)
  {
    return this.httpClient.post<any>(AppSettings.URLs.Student.AddStudent,value);
  }
  
  getStudentById(studentid)
  {
    return this.httpClient.get<any>(AppSettings.URLs.Student.GetStudentById+studentid);
  }
}
