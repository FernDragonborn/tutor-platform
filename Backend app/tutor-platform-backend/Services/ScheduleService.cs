using TutorPlatformBackend.DbContext;
using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.Services;

public class ScheduleService
{
    private readonly TutorPlatformDbContext _context;
    public ScheduleService(TutorPlatformDbContext context)
    {
        _context = context;
    }

    public static bool[] ConvertBoolTableToArr(bool[,] table)
    {
        const int rows = 7;
        const int cols = 27;

        if (table.Length != rows || table.GetUpperBound(2) + 1 != cols)
        {
            throw new ArgumentException("Довжина масиву повинна бути 7 * 27 = 189.");
        }


        int totalElements = rows * cols;

        bool[] result = new bool[totalElements];

        int index = 0;
        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                result[index++] = table[i, j];
            }
        }

        return result;
    }

    public static bool[,] ConvertBoolArrToTable(bool[] arr)
    {
        const int rows = 7;
        const int cols = 27;

        // Проверим, что размер массива соответствует размеру таблицы
        if (arr.Length != rows * cols)
        {
            throw new ArgumentException($"Arr lenght was {arr.Length}, but must be 189.");
        }

        // Создадим таблицу размером 7 x 27
        bool[,] table = new bool[rows, cols];

        // Заполним таблицу значениями из одномерного массива
        for (int i = 0; i < arr.Length; i++)
        {
            int row = i / cols;
            int col = i % cols;
            table[row, col] = arr[i];
        }
        return table;
    }

    internal void BookLesson(StudentLesson lesson)
    {
        throw new NotImplementedException();
    }

    internal Result<bool[,]?> GetTutorSchedule(Guid tutorId)
    {
        var tutor = _context.Tutors.Find(tutorId);
        if (tutor is null) new Result<bool[,]?>(false, null, "Tutor not foud by provided id");

        var table = ConvertBoolArrToTable(tutor.Schedule.ToArray());
        return new Result<bool[,]?>(true, table, "");
    }

    internal Result UpdateTutorSchedule(bool[,] updatedSchedule, string tutorId)
    {
        if (!Guid.TryParse(tutorId, out var tutorGuid))
        {
            return new Result(false, "Id wasn't suitable for guid signature");
        }
        EFBoolCollection boolCollection = new();
        boolCollection.AddRange(updatedSchedule.Cast<bool>().ToArray());
        var tutor = _context.Tutors.Find(tutorGuid);
        if (tutor is null)
        {
            return TutorNotFoundById();
        }


        return new Result(true, "");
    }

    private Result<T?> TutorNotFoundById<T>() => new(false, default, "Tutor not foud by provided id");
    private Result TutorNotFoundById() => new(false, "Tutor not foud by provided id");

}
