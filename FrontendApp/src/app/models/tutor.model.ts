import { AgeGroup } from "../enums/age-group.enum";
import { Experience } from "../enums/experience.enum";
import { Gender } from "../enums/gernder.enum";

class TutorDto {
    id: string;
    login: string;
    password: string;
    role: string;
    firstName: string;
    lastName: string;
    jwtToken: string;
    email: string;
    phoneNumber: string;
    viber: string;
    telegram: string;
    isVerified: boolean;
    isProfileActive: boolean;
    experience: Experience;
    subjects: SubjectDTO[];
    educations: EducationDTO[];
    city: string;
    canHost: boolean;
    canTravel: boolean;
    canTeachOnline: boolean;
    shortDescription: string;
    detailedDescription: string;
    ageGroup: AgeGroup;
    gender: Gender;
    youtubeVideoLink: string;
    schedule: boolean[][];
    reviews: ReviewDTO[];

    constructor(
        id: string = "",
        login: string = "",
        password: string = "",
        role: string = "",
        firstName: string = "",
        lastName: string = "",
        jwtToken: string = "",
        email: string = "",
        phoneNumber: string = "",
        viber: string = "",
        telegram: string = "",
        isVerified: boolean = false,
        isProfileActive: boolean = false,
        experience: Experience = Experience.LessThan1,
        subjects: SubjectDTO[] = [],
        educations: EducationDTO[] = [],
        city: string = "",
        canHost: boolean = false,
        canTravel: boolean = false,
        canTeachOnline: boolean = false,
        shortDescription: string = "",
        detailedDescription: string = "",
        ageGroup: AgeGroup = AgeGroup.Age18_25,
        gender: Gender = Gender.Other,
        youtubeVideoLink: string = "",
        schedule: boolean[][] = [],
        reviews: ReviewDTO[] = []
    ) {
        this.id = id;
        this.login = login;
        this.password = password;
        this.role = role;
        this.firstName = firstName;
        this.lastName = lastName;
        this.jwtToken = jwtToken;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.viber = viber;
        this.telegram = telegram;
        this.isVerified = isVerified;
        this.isProfileActive = isProfileActive;
        this.experience = experience;
        this.subjects = subjects;
        this.educations = educations;
        this.city = city;
        this.canHost = canHost;
        this.canTravel = canTravel;
        this.canTeachOnline = canTeachOnline;
        this.shortDescription = shortDescription;
        this.detailedDescription = detailedDescription;
        this.ageGroup = ageGroup;
        this.gender = gender;
        this.youtubeVideoLink = youtubeVideoLink;
        this.schedule = schedule;
        this.reviews = reviews;
    }
}
