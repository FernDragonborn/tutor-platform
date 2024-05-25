export class SubjectDto {
    subjectName: string;
    price: number;
    grades: string[];
    description: string;

    constructor(subjectName: string, price: number, grades: string[], description: string) {
        this.subjectName = subjectName;
        this.price = price;
        this.grades = grades;
        this.description = description;
    }
}