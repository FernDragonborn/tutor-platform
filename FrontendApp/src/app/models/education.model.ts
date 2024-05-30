import { Degree } from "../enums/degree.enum";

export class EducationDto {
    universityName: string;
    degree: Degree;
    graduationYear: number;

    constructor(universityName: string, degree: Degree, graduationYear: number, certificates: string[]) {
        this.universityName = universityName;
        this.degree = degree;
        this.graduationYear = graduationYear;
    }
}