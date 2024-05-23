export enum Subject {
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

export const SubjectNamesUa: { [key in Subject]: string } = {
    [Subject.Junior]: 'Молодші класи',
    [Subject.Maths]: 'Математика',
    [Subject.WorldHistory]: 'Всесвітня історія',
    [Subject.UkrainianHistory]: 'Історія України',
    [Subject.WorldLiterature]: 'Зарубіжна література',
    [Subject.UkrainianLiterature]: 'Українська література',
    [Subject.Geography]: 'Географія',
    [Subject.ComputerScience]: 'Інформатика',
    [Subject.Chemistry]: 'Хімія',
    [Subject.Physics]: 'Фізика',
    [Subject.Ukrainian]: 'Українська мова',
    [Subject.English]: 'Англійська мова',
    [Subject.German]: 'Німецька мова',
    [Subject.French]: 'Французька мова',
    [Subject.Polish]: 'Польська мова',
    [Subject.Spanish]: 'Іспанська мова'
};
