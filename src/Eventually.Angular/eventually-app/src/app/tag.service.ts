import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Tag } from './tag';

@Injectable()
export class TagService {
    private eventsUrl = 'http://home.naslund.io:5000/api/events';

    constructor(private http: Http) { }

    getTagsByEventId(id: number): Observable<Tag[]> {
        return this.http.get(this.eventsUrl + '/' + id + '/tags').map(this.extractData);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
}