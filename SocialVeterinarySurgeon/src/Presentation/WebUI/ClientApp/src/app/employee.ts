import { Pet } from './pet';

export class Employee {
    constructor(
        public id?: number,
        public firstName?: string,
        public lastName?: string,
        public mediaInteractivaEmployee?: boolean,
        public pet?: Pet
    ) { }
}