export enum SubjectType {
    Junior = 'Junior',
    Maths = 'Maths',
    WorldHistory = 'WorldHistory',
    UkrainianHistory = 'UkrainianHistory',
    WorldLiterature = 'WorldLiterature',
    UkrainianLiterature = 'UkrainianLiterature',
    Geography = 'Geography',
    ComputerScience = 'ComputerScience',
    Chemistry = 'Chemistry',
    Physics = 'Physics',
    Ukrainian = 'Ukrainian',
    English = 'English',
    German = 'German',
    French = 'French',
    Polish = 'Polish',
    Spanish = 'Spanish'
}

export const SubjectNamesUa: { [key in SubjectType]: string } = {
    [SubjectType.Junior]: 'Молодші класи',
    [SubjectType.Maths]: 'Математика',
    [SubjectType.WorldHistory]: 'Всесвітня історія',
    [SubjectType.UkrainianHistory]: 'Історія України',
    [SubjectType.WorldLiterature]: 'Зарубіжна література',
    [SubjectType.UkrainianLiterature]: 'Українська література',
    [SubjectType.Geography]: 'Географія',
    [SubjectType.ComputerScience]: 'Інформатика',
    [SubjectType.Chemistry]: 'Хімія',
    [SubjectType.Physics]: 'Фізика',
    [SubjectType.Ukrainian]: 'Українська мова',
    [SubjectType.English]: 'Англійська мова',
    [SubjectType.German]: 'Німецька мова',
    [SubjectType.French]: 'Французька мова',
    [SubjectType.Polish]: 'Польська мова',
    [SubjectType.Spanish]: 'Іспанська мова'
};
