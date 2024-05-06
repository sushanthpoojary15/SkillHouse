import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'myapp--no-standalone';

  
  constructor(private router: Router) {
   
    
  }

  redirectToDashboard()
  {
    this.router.navigate(['/dashboard']);
  }

  redirectToAddStudent()
  {
    this.router.navigate(['/add-student']);
  }
  redirectToStastics()
  {
    this.router.navigate(['/student-stastics']);
  }
}
