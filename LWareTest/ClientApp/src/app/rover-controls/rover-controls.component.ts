import { Component } from '@angular/core';
import { RoverCommand } from "../models/RoverCommand";
import {RoverDataService} from "../services/rover-data.service";

@Component({
  selector: 'rover-controls',
  templateUrl: './rover-controls.component.html',
  styleUrls: ['./rover-controls.component.css']
})
export class RoverControlsComponent {
  commands: RoverCommand[];
  roverDataService: RoverDataService;
  roverUpdateStatus: string;
  roverUpdateError: string;

  constructor(roverDataService: RoverDataService) {
    this.roverDataService= roverDataService;
    this.commands = [];
  }

  addControl(direction: string) {
    let id = this.commands.length === 0 ? 1: Math.max.apply(Math, this.commands.map(function(o) { return o.id; })) + 1;
    this.commands.push(new RoverCommand(id, direction, null));
    this.roverUpdateStatus = "";
    this.roverUpdateError = "";
  }

  removeCommand(command: RoverCommand) {
    this.commands.splice(this.commands.indexOf(command), 1);
  }

  sendCommands() {
    let payload = this.commands.map(c => c.direction === "F" ? c.distance.toString() : c.direction);
    this.roverDataService.SendRoverCommands(payload).subscribe(()=>{
      this.roverUpdateStatus = "Rover position updated successfully";
      this.commands =[];
    }, (err) =>{
      this.roverUpdateError = "Something happened while moving the rover";
      console.error(err);
    })
  }
}
