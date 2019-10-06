import {Component, Inject, OnInit} from '@angular/core';
import {RoverDataService} from "../services/rover-data.service";
import {RoverCurrentPositionDetails} from "../models/RoverCurrentPositionDetails";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit{
  public roverPositionDetails: RoverCurrentPositionDetails;
  private roverDataService: RoverDataService;

  constructor(roverDataService: RoverDataService) {
    this.roverDataService = roverDataService;
  }

  ngOnInit(){
    this.getCurrentRoverPosition();
  }

  getCurrentRoverPosition(){
    this.roverDataService.GetRoverPosition().subscribe(positionDetails => {
      this.roverPositionDetails = positionDetails;
    });
  }
}
