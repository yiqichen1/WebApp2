import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  //create array of type teammember to hold all the members
  public members: TeamMember[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //getting team members from controller 
    http.get<TeamMember[]>(baseUrl + 'api/Team/GetAllTeamMembers').subscribe(result => {
      console.log(result);
      this.members = result;
    }, error => console.error(error));
  }
}

interface TeamMember {
  firstName: string;
  email: string;
}
