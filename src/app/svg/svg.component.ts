import {Component, OnInit, Renderer2} from '@angular/core';
import {DataService} from "../services/data.service";

@Component({
    selector: 'app-svg',
    templateUrl: './svg.component.svg',
    styleUrls: ['./svg.component.css'],
    providers: [DataService]
})
export class SvgComponent implements OnInit {
    fillColor = 'rgb(255, 0, 0)';
    
    constructor(private datasevice: DataService, private renderer: Renderer2) {}

    public changeColor() {
        const r = Math.floor(Math.random() * 256);
        const g = Math.floor(Math.random() * 256);
        const b = Math.floor(Math.random() * 256);
        this.fillColor = `rgb(${r}, ${g}, ${b})`;
    }
    
    getInitialSize(): number[]{
        return this.datasevice.getInitialSize();
    }

    ngOnInit(): void {
        // let initialSize = this.getInitialSize();
        // var rect = document.getElementById('rectangle');
        // this.renderer.setStyle(rect, 'height', initialSize[0]);
        // this.renderer.setStyle(rect, 'width', initialSize[1]);
    }
}