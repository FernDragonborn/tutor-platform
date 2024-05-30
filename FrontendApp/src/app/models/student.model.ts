import { StudentLessonDto } from "./student-lesson.model";

export class StudentDto{
    Id: String;
    Login: String;
    Password: String;
    JwtToken: String;
    PhoneNumber: String | null;
    FirstName: String | null;
    LastName: String | null;
    Lessons: StudentLessonDto[] | null;
}