import {Component, OnInit} from '@angular/core';
import {DataService} from "../services/data.service";
import {Size} from "../models/size";

@Component({
    selector: 'app-svg',
    templateUrl: "./svg.component.svg",
    styleUrls: ['./svg.component.css'],
    providers: [DataService]
})
export class SvgComponent implements OnInit {
    
    constructor(private datasevice: DataService) {}
    
    private initialSize: Size;
    private currentSize: Size;
    public perimeter: string;
    
    getInitialSize(){
        this.datasevice.getInitialSize().subscribe((initialSize: Size) => {
            this.initialSize = initialSize;
        });
    }
    
    getPerimeter(){
        this.datasevice.getPerimeter(this.currentSize).subscribe((perimeter: string) =>{
            this.perimeter = perimeter;
        })
    }

    ngOnInit(): void {
        this.getInitialSize();
        var rect = document.getElementById('rectangle');
        rect.style.height = this.initialSize.height;
        rect.style.width = this.initialSize.width;
        this.currentSize.height = rect.style.height;
        this.currentSize.width = rect.style.width;
    }
}