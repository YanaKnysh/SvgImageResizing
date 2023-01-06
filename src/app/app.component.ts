import {Component} from '@angular/core';
import {SvgComponent} from "./svg/svg.component";

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent {
    constructor(private svgComponent:SvgComponent) {
        this.perimeter = this.svgComponent.perimeter;
    }
    
    public perimeter: string;
}