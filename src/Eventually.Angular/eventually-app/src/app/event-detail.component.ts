import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import 'rxjs/add/operator/switchMap';

import { Event } from './event';
import { Tag } from './tag';
import { EventService } from './event.service';
import { TagService } from './tag.service';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./app.component.css'],
  providers: [EventService, TagService] 
})
export class EventDetailComponent implements OnInit {
    event: Event;
    tags: Tag[];

    constructor(private eventService: EventService, private tagService: TagService, private route: ActivatedRoute, private location: Location) { }

    ngOnInit(): void {
        this.route.params
            .switchMap((params: Params) => this.eventService.getEvent(+params['id']))
            .subscribe(event => this.event = event);

        this.route.params
            .switchMap((params: Params) => this.tagService.getTagsByEventId(+params['id']))
            .subscribe(tags => this.tags = tags);
    }
}
