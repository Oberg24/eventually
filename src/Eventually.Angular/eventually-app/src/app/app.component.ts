import { Component } from '@angular/core';

import { Event } from './event';
import { EventService } from './event.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  events: Event[];
  selectedEvent: Event;
}


