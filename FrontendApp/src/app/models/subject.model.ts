import { GradeLevelsDto } from "./grade-level.model";

export class SubjectDto {
    subjectName: string;
    price: number;
    gradeLevels: GradeLevelsDto[];
    description: string;

    constructor(subjectName: string, price: number, gradeLevels: GradeLevelsDto[], description: string) {
        this.subjectName = subjectName;
        this.price = price;
        this.gradeLevels = gradeLevels;
        this.description = description;
    }
}