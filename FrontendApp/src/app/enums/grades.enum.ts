export enum Grades {
    Grades1_4 = 'Grades1_4',
    Grades5_6 = 'Grades5_6',
    Grades7_9 = 'Grades7_9',
    Grades10_11 = 'Grades10_11',
    DPA = 'DPA',
    ZNO = 'ZNO',
    Olympiads = 'Olympiads',
    University = 'University'
}

export const GradesNamesUa: { [key in Grades]: string } = {
    [Grades.Grades1_4]: '1-4 класи',
    [Grades.Grades5_6]: '5-6 класи',
    [Grades.Grades7_9]: '7-9 класи',
    [Grades.Grades10_11]: '10-11 класи',
    [Grades.DPA]: 'ДПА',
    [Grades.ZNO]: 'ЗНО',
    [Grades.Olympiads]: 'Олімпіади',
    [Grades.University]: 'Університет'
};