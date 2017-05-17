import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Event } from './event';

@Injectable()
export class EventService {
    private eventsUrl = 'http://home.naslund.io:5000/api/events';

    constructor(private http: Http) { }

    getEvents(): Observable<Event[]> {
        return this.http.get(this.eventsUrl).map(this.extractData);
    }

    getEventsByTagId(tagId: number): Observable<Event[]> {
        return this.http.get(this.eventsUrl + '/tags/' + tagId).map(this.extractData);
    }

    getEvent(id: number): Observable<Event> {
        return this.http.get(this.eventsUrl + '/' + id).map(this.extractData);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
}
