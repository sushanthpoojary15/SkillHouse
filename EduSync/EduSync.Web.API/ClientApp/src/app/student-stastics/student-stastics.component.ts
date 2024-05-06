import { Component, OnInit } from '@angular/core';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { StudentServiceService } from 'src/service/student-service.service';
@Component({
  selector: 'app-student-stastics',
  templateUrl: './student-stastics.component.html',
  styleUrls: ['./student-stastics.component.css']
})


export class StudentStasticsComponent implements OnInit {
  name = 'Angular';
 
  width: number = 500;
  height: number = 300;
  fitContainer: boolean = false;

    view: [700, 400];
  // options for the chart
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  xAxisLabel = 'Year';
  showYAxisLabel = true;
  yAxisLabel = 'Student Count';
  timeline = true;
  doughnut = true;
  colorScheme = {
    domain: ['#9370DB', '#87CEFA', '#FA8072', '#FF7F50', '#90EE90', '#9370DB']
  };
 
 graphValues=[];
  //pie
  showLabels = true;
  studentList;
  yearlyCount = {
    2020: 0,
    2021: 0,
    2022: 0,
    2023: 0,
    2024: 0,
  };
  // data goes here

constructor(private student:StudentServiceService) { 

  }

  ngOnInit(): void {
    this.student.getAllStudents().subscribe((res)=>{
      this.studentList=res;

      this.studentList.forEach((x)=>{
        if(x.enrollmentYear in this.yearlyCount)
        {
          this.yearlyCount[x.enrollmentYear]++;
        }
      })

      this.updateGraph()
      
      
    });
  }
  yAxisFormat(val: any) {
    if (val % 1 > 0) return '';
    return val;
  }
  updateGraph()
  {
     this.graphValues = [
      {
        "name": "2020",
        "value":this.yearlyCount[2020]
      },
      {
        "name": "2021",
        "value": this.yearlyCount[2021]
      },
      {
        "name": "2022",
        "value": this.yearlyCount[2022]
      },
      {
        "name": "2023",
        "value": this.yearlyCount[2023]
      },
      {
        "name":"2024",
        "value": this.yearlyCount[2024]
      }
    ];
  }

}
