import { Injectable } from '@angular/core';

import { Event } from './event';

@Injectable()
export class EventService {
    getEvents(): Promise<Event[]> {
        return Promise.resolve(EVENTS);
    }
}
