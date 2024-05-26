import { AgeGroup } from "../enums/age-group.enum";
import { Experience } from "../enums/experience.enum";
import { Gender } from "../enums/gernder.enum";
import { EducationDto } from "./education.model";
import { ReviewDto } from "./review.model";
import { SubjectDto } from "./subject.model";


export class TutorDto {
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
    viber: string;
    telegram: string;
    isVerified: boolean | null;
    isProfileActive: boolean;
    experience: Experience | null;
    subjects: SubjectDto[];
    educations: EducationDto[];
    shortDescription: string;
    detailedDescription: string;
    profilePic: string | null;
    priceToShow: number | null;
    ageGroup: AgeGroup | null;
    gender: Gender | null;
    youtubeVideoLink: string;
    schedule: boolean[][];
    reviews: ReviewDto[];

    constructor(
        firstName: string = "",
        lastName: string = "",
        email: string = "",
        phoneNumber: string = "",
        viber: string = "",
        telegram: string = "",
        isVerified: boolean | null = null,
        isProfileActive: boolean = false,
        experience: Experience | null = null,
        subjects: SubjectDto[] = [],
        educations: EducationDto[] = [],
        shortDescription: string = "",
        detailedDescription: string = "",
        profilePic: string | null = null, 
        ageGroup: AgeGroup | null = null,
        gender: Gender | null = null,
        youtubeVideoLink: string = "",
        schedule: boolean[][] = [],
        reviews: ReviewDto[] = []
    ) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.viber = viber;
        this.telegram = telegram;
        this.isVerified = isVerified;
        this.isProfileActive = isProfileActive;
        this.experience = experience;
        this.subjects = subjects;
        this.educations = educations;
        this.shortDescription = shortDescription;
        this.detailedDescription = detailedDescription;
        this.profilePic = profilePic;
        this.ageGroup = ageGroup;
        this.gender = gender;
        this.youtubeVideoLink = youtubeVideoLink;
        this.schedule = schedule;
        this.reviews = reviews;
    }
}
