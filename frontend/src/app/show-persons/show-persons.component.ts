import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '../api-service.service';

@Component({
  selector: 'show-persons',
  templateUrl: './show-persons.component.html',
  styleUrl: './show-persons.component.css'
})
export class ShowPersonsComponent implements OnInit {
  persons: any;
  constructor(private service: ApiServiceService) { }

  ngOnInit(): void {
    this.service
      .getPersons()
      .subscribe(data => {
        this.persons = data;
      })
  }
}
