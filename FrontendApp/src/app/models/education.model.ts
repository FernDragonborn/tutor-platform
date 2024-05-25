export class EducationDto {
    universityName: string;
    degree: string;
    graduationYear: number;
    certificates: string[];

    constructor(universityName: string, degree: string, graduationYear: number, certificates: string[]) {
        this.universityName = universityName;
        this.degree = degree;
        this.graduationYear = graduationYear;
        this.certificates = certificates;
    }
}