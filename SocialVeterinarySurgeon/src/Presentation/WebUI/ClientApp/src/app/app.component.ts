import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Employee } from './employee';
import { Pet } from './pet';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    employee: Employee = new Employee();
    pet: Pet = new Pet();
    employees: Employee[];
    tableMode: boolean = true;

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadEmployees();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadEmployees() {
        this.dataService.getEmployees()
            .subscribe((data: Employee[]) => this.employees = data);
    }
    // сохранение данных
    save() {
        if (this.employee.id == null) {
            this.dataService.createEmployee(this.employee)
                .subscribe(data => this.loadEmployees());
        } else {
            this.dataService.updateEmployee(this.employee)
                .subscribe(data => this.loadEmployees());
        }
        this.cancel();
    }
    editProduct(e: Employee) {
        this.employee = e;
    }
    cancel() {
        this.employee = new Employee();
        this.employee.pet = this.pet;
        this.tableMode = true;
    }
    delete(e: Employee) {
        this.dataService.deleteEmployee(e.id)
            .subscribe(data => this.loadEmployees());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}