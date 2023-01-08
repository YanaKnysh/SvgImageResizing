import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { SvgComponent } from "./svg/svg.component";
import { AppComponent } from "./app.component";
import { DataService } from "./services/data.service";
import { HttpClientModule } from "@angular/common/http";
import { ResizeObserverDirective } from "./svg/resize-observer.directive";

@NgModule({
    imports: [ BrowserModule, FormsModule, HttpClientModule ],
    declarations: [ AppComponent, SvgComponent, ResizeObserverDirective ],
    bootstrap: [ AppComponent ],
    providers: [ DataService ]
})
export class AppModule { }