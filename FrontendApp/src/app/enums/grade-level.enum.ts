export enum GradeLevel {
    Grades1_4 = 'Grades1_4',
    Grades5_6 = 'Grades5_6',
    Grades7_9 = 'Grades7_9',
    Grades10_11 = 'Grades10_11',
    DPA = 'DPA',
    ZNO = 'ZNO',
    Olympiads = 'Olympiads',
    University = 'University'
}

export const GradeNamesUa: { [key in GradeLevel]: string } = {
    [GradeLevel.Grades1_4]: '1-4 класи',
    [GradeLevel.Grades5_6]: '5-6 класи',
    [GradeLevel.Grades7_9]: '7-9 класи',
    [GradeLevel.Grades10_11]: '10-11 класи',
    [GradeLevel.DPA]: 'ДПА',
    [GradeLevel.ZNO]: 'ЗНО',
    [GradeLevel.Olympiads]: 'Олімпіади',
    [GradeLevel.University]: 'Університет'
};