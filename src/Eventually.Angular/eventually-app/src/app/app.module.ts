import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { EventAllComponent } from './event-all.component';
import { EventDetailComponent } from './event-detail.component';

const appRoutes: Routes = [
    { path: 'events', component: EventAllComponent },
    { path: 'event/:id', component: EventDetailComponent },
    { path: '', redirectTo: '/events', pathMatch: 'full' }
];

@NgModule({
    declarations: [
        AppComponent,
        EventAllComponent,
        EventDetailComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule.forRoot(appRoutes)
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }