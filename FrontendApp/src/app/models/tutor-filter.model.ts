import { GradeLevel } from "../enums/grade-level.enum";
import { SubjectType } from "../enums/subject-type.enum";

export class TutorFilterDto
{
    public Subject: SubjectType | null = null; 

    public GradeLevel: GradeLevel | null = null; 

    public MinPrice: number | null = null; 

    public MaxPrice: number | null = null;

    public Page: number | null = null;
}