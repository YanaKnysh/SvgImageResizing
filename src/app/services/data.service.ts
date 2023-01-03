import { HttpClient } from '@angular/common/http';
import {Size} from "../models/size";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";

@Injectable({
    providedIn: 'any',
})
export class DataService{
    
    constructor(private http:HttpClient) {
    }
    
    private baseUrl = 'http://localhost:5131/rectangle'

    getInitialSize(): Observable<Size> {

        return this.http.get<Size>(`${this.baseUrl}/initialsize`);
    }

    getPerimeter(size: Size): Observable<string> {

        return this.http.get<string>(`${this.baseUrl}/perimeter`);
    }
}