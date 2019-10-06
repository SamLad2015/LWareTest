import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { RoverControlsComponent } from './rover-controls/rover-controls.component';
import { HomeComponent } from './home/home.component';
import { RoverControlComponent } from './rover-controls/rover-control/rover-control.component';
import {RoverDataService} from "./services/rover-data.service";

@NgModule({
  declarations: [
    AppComponent,
    RoverControlsComponent,
    HomeComponent,
    RoverControlComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [RoverDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
