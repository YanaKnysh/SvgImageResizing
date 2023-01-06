import {Component, OnInit, ChangeDetectorRef} from '@angular/core';
import {DataService} from "../services/data.service";
import {Size} from "../models/size";

@Component({
    selector: 'app-svg',
    templateUrl: "./svg.component.html",
    styleUrls: ['./svg.component.scss'],
    providers: [DataService]
})
export class SvgComponent implements OnInit {
    
    constructor(private datasevice: DataService) {}
    
    private initialSize: Size;
    private currentSize: Size;
    public perimeter: string;
    
    getInitialSize(){
        let result = this.datasevice.getInitialSize().subscribe((initialSize: Size) => {
            this.initialSize = initialSize;
            this.getPerimeterBySize();
            //console.log(this.initialSize);
        });
    }

    getPerimeterBySize(){
        this.datasevice.getPerimeterBySize(this.initialSize).subscribe((perimeter: string) =>{
            this.perimeter = perimeter;
            console.log(this.perimeter);
        })
    }

    ngOnInit(): void {
        this.getInitialSize();
        var rect = document.getElementById('rectangle');
        // rect.style.height = this.initialSize.height;
        // rect.style.width = this.initialSize.width;
        // this.currentSize.height = rect.style.height;
        // this.currentSize.width = rect.style.width;
        //this.getPerimeterBySize();
    }
}