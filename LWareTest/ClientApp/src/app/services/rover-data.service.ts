import {Inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {RoverCurrentPositionDetails} from "../models/RoverCurrentPositionDetails";

@Injectable()
export class RoverDataService {
  http: HttpClient;
  baseUrl: string;
  public roverPositionDetails: RoverCurrentPositionDetails;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  GetRoverPosition() {
    return this.http.get<RoverCurrentPositionDetails>(this.baseUrl + 'api/LwRover');
  }

  SendRoverCommands(commands: string[]) {
    return this.http.post(this.baseUrl + 'api/LwRover', commands, {
      headers: {'Content-Type' : 'application/json'}
    });
  }
}
