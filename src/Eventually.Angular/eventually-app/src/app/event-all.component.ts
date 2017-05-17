import { Component, OnInit } from '@angular/core';

import { Event } from './event';
import { EventService } from './event.service';

import { Tag } from './tag';
import { TagService } from './tag.service';


@Component({
  selector: 'app-event-all',
  templateUrl: './event-all.component.html',
  styleUrls: ['./event-all.component.css'],
  providers: [ EventService, TagService ] 
})

export class EventAllComponent implements OnInit {
    events: Event[];
    tags: Tag[];

    constructor(private eventService: EventService, private tagService: TagService) { }

    ngOnInit() {
        this.getEvents();
        this.getTags();
    }

    getTags() {
        this.tagService.getAllTags().subscribe(tags => this.tags = tags);
    }

    getEventsWithTag(tagId: number) {
        this.eventService.getEventsByTagId(tagId).subscribe(events => {
            events.forEach(function (item) {
                item.goldStars = (Math.floor(Math.random() * (100 - 0 + 1)) + 0);
            });
            this.events = events;
        });
    }

    toggleGoldStar(event: Event) {
        event.showGold = !event.showGold;
        if(event.goldStars > 0) {
            if(event.showGold){
                event.goldStars += 1;
            } else {
                event.goldStars -= 1;
            }
        } else {
            event.goldStars = 1;
        }
    }
    
    getEvents() {
        this.eventService.getEvents().subscribe(events => { events.forEach(function(item){
        item.goldStars = (Math.floor(Math.random() * (100 - 0 + 1)) + 0);
        }); this.events = events; });
    }
}
