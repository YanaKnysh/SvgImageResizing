import {HttpClient, HttpHeaders, HttpParamsOptions} from '@angular/common/http';
import {Size} from "../models/size";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";

@Injectable({
    providedIn: 'any',
})
export class DataService{
    
    constructor(private http:HttpClient) {
        this.httpHeaders = new HttpHeaders()
            .set('content-type', 'application/json')
            .set('Access-Control-Allow-Origin', '*');
    }
    
    // private baseUrl = 'http://localhost:5131/rectangle'
    private baseUrl = '/api/rectangle'
    private httpHeaders;

    getInitialSize(): Observable<Size> {

        return this.http.get<Size>(`${this.baseUrl}/initialsize`,{headers: new HttpHeaders()
                .set('content-type', 'application/json')
                .set('Access-Control-Allow-Origin', '*')});
    }

    getPerimeter(size: Size): Observable<string> {

        return this.http.get<string>(`${this.baseUrl}/perimeter`);
    }
}