import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs/Observable';

import { Event } from './event';
import { Tag } from './tag';
import { EventService } from './event.service';


@Component({
  selector: 'app-event-all',
  templateUrl: './event-all.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ EventService ] 
})

export class EventAllComponent implements OnInit {
    events: Event[];

    constructor(private eventService: EventService) { }

    ngOnInit() {
        this.getHeroes();
    }

    getHeroes() {
        this.eventService.getEvents().subscribe(events => this.events = events);
    }
}
