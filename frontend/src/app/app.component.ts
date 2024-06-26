import {Component, OnInit} from '@angular/core';
import {SignalRService} from "./services/signalR.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements  OnInit{
  title = 'frontend';
  constructor(
    public signalRService: SignalRService
  ) {
  }
  ngOnInit() {
    this.signalRService.otvori_ws_konekciju();
  }
}
