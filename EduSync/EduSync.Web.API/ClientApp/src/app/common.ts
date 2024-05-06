
export class AppSettings {
 
    // public static ApiEndpoint: string = "https://h2hapitest.azurewebsites.net/api"; //todo: dev URL
    // public static ApiHost: string = "https://h2hapitest.azurewebsites.net/"; //todo: dev URL
  
    // public static ApiHost: string = "http://192.168.10.28:2022/"; //todo: dev URL
    // public static ApiEndpoint: string = "http://localhost:59122/api";
  
    public static ApiHost: string = 'https://localhost:7217/'; //todo: dev URL
    public static ApiEndpoint: string = 'https://localhost:7217/api';

    public static URLs = {
        Student: {
          GetAllStudents: AppSettings.ApiEndpoint + '/Student',
          DeleteStudentById:AppSettings.ApiEndpoint+'/Student?studentId=',
          AddStudent:AppSettings.ApiEndpoint+'/Student',
          GetStudentById:AppSettings.ApiEndpoint+'/Student/'
        }
    }
}