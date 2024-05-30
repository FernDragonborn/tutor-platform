import { GradeLevel } from "../enums/grade-level.enum";

export class StudentLessonDto{
    tutorId : String;
    studentId: String;  
    LessonTime: Date;
    GradeLevel: GradeLevel;
    Price: Number; 
    TutorPhoneNumber: String;
    TutorViber: String;
    TutorTelegram: String;  
}