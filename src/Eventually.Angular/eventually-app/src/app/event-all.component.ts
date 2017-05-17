import { Component, OnInit } from '@angular/core';

import { Event } from './event';
import { EventService } from './event.service';


@Component({
  selector: 'app-event-all',
  templateUrl: './event-all.component.html',
  styleUrls: ['./event-all.component.css'],
  providers: [ EventService ] 
})

export class EventAllComponent implements OnInit {
    events: Event[];

    constructor(private eventService: EventService) { }

    ngOnInit() {
        this.getEvents();
    }

    getEvents() {
        this.eventService.getEvents().subscribe(events => this.events = events);
    }
}
