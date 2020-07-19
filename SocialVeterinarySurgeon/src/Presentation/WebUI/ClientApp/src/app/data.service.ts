﻿import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from './employee';

@Injectable()
export class DataService {

    private url = "/v1/employee";

    constructor(private http: HttpClient) {
    }

    getEmployees() {
        return this.http.get(this.url);
    }

    getEmployee(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createEmployee(employee: Employee) {
        return this.http.post(this.url, employee);
    }
    updateEmployee(employee: Employee) {

        return this.http.post(this.url, employee);
    }
    deleteEmployee(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}
