import { Component, Input, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms'

@Component({
  selector: 'app-addmember-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {

  //create string array to hold name and email submission
  
  public sqlCommand:string;
  baseUrl: string;


  onClickDelete(delFirstName:string){
    this.sqlCommand =  "Delete from Team where Name ="+delFirstName;
    this.http.post(this.baseUrl + 'api/Team/RemoveTeamMember', this.sqlCommand).subscribe(
      result => console.log(result)
    );
  }

  onClick(firstName:string, emailAddress:string){
    this.sqlCommand = "Insert into Team(Name, Email) values(" + firstName + "," + emailAddress + ")";
    this.http.post(this.baseUrl + 'api/Team/AddTeamMember/', this.sqlCommand ).subscribe(
      result => console.log(result)
    );
  }
  constructor(private http:HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  

}
