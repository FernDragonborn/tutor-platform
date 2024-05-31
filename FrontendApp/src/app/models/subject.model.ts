import { SubjectType } from 'src/app/enums/subject-type.enum';
import { GradeLevelsDto } from "./grade-level.model";

export class SubjectDto {
    subjectType: SubjectType;
    price: number;
    gradeLevels: GradeLevelsDto[];
    description: string;

    constructor(SubjectType: SubjectType, price: number, gradeLevels: GradeLevelsDto[], description: string) {
        this.subjectType = SubjectType;
        this.price = price;
        this.gradeLevels = gradeLevels;
        this.description = description;
    }
}