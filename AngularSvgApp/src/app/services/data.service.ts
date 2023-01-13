import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Size} from "../models/size";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";

@Injectable({
    providedIn: 'any',
})
export class DataService{
    
    constructor(private http:HttpClient) {
    }
    
    private baseUrl = '/api/rectangle'

    getInitialSize(): Observable<Size> {
        return this.http.get<Size>(`${this.baseUrl}/initial-size`);
    }

    getPerimeterBySize(size: Size): Observable<string> {
        return this.http.post<string>(`${this.baseUrl}/perimeter`, size, {headers: new HttpHeaders()
                .set('content-type', 'application/json')});
    }
}