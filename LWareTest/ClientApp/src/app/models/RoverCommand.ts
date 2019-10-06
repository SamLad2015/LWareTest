export class RoverCommand {
  id: number;
  direction: string;
  distance: number;
  constructor (_id: number, _direction: string, _distance: number) {
    this.id = _id;
    this.direction = _direction;
    this.distance = _distance;
  }
}
