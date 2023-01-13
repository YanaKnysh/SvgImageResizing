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
    
    constructor(private datasevice: DataService, private changeDetectorRef: ChangeDetectorRef) {}
    
    public initialSize: Size;
    public currentSize: Size = <Size>{};
    public perimeter: string;
    
    getAndSetInitialSize(){
        this.datasevice.getInitialSize().subscribe((initialSize: Size) => {
            this.initialSize = initialSize;
            this.setRectangleSize(this.initialSize);
        });
    }

    getPerimeterBySize(size: Size){
        this.datasevice.getPerimeterBySize(size).subscribe((perimeter: string) =>{
            this.perimeter = perimeter;
            this.changeDetectorRef.detectChanges();
        })
    }
    
    setRectangleSize(size: Size){
        let rect = document.getElementById('svg_id');
        rect.setAttribute('height', size.height.toString());
        rect.setAttribute('width', size.width.toString());
        this.currentSize.height = Number(rect.getAttribute('height'));
        this.currentSize.width = Number(rect.getAttribute('width'));
        this.getPerimeterBySize(this.currentSize);
    }
    
    onResize(ev){
        this.currentSize.width = ev.contentRect.width;
        this.currentSize.height = ev.contentRect.height;
    }

    ngOnInit(): void {
        this.getAndSetInitialSize();
    }
}