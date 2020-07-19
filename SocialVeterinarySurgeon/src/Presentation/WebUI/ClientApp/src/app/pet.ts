import { Employee } from './employee';

export class Pet {
    constructor(
        public id?: number,
        public name?: string,
        public type?: string,
        public ownerId?: number
    ) { }
}