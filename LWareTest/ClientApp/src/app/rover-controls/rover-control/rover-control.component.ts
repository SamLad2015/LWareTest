import {Component, Input, OnInit} from '@angular/core';
import {RoverCommand} from "../../models/RoverCommand";

@Component({
  selector: 'rover-control',
  templateUrl: './rover-control.component.html',
  styleUrls: ['./rover-control.component.css']
})
export class RoverControlComponent implements OnInit {
  @Input() roverCommand: RoverCommand;
  isNotDirectional: boolean;

  constructor() { }

  ngOnInit() {
    this.isNotDirectional = this.roverCommand.direction === 'F';
  }
}
