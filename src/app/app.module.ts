import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import {SvgComponent} from "./svg/svg.component";
import {AppComponent} from "./app.component";
import {DataService} from "./services/data.service";
import {HttpClientModule} from "@angular/common/http";
@NgModule({
    imports: [ BrowserModule, FormsModule, HttpClientModule ],
    declarations: [ AppComponent, SvgComponent ],
    bootstrap: [ AppComponent ],
    providers: [DataService, SvgComponent]
})
export class AppModule { }