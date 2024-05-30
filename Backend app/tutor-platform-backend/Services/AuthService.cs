using TutorPlatformBackend.DbContext;
using TutorPlatformBackend.DTOs;
using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.Services;

public static class AuthService
{
    private static readonly TutorPlatformDbContext _context;
    static AuthService()
    {
        _context = ContextFactory.CreateNew();
    }

    public static Result<UserDto?> LoginStudent(UserDto studentDto)
    {
        var student = _context.Students.FirstOrDefault(x => x.Login == studentDto.Login);
        if (student is null) { return new Result<UserDto?>(false, null, "Wrong login or password"); }

        if (!BCrypt.Net.BCrypt.Verify(studentDto.Password + student.PasswordSalt, student.PasswordHash))
        {
            return new Result<UserDto?>(false, null, "Wrong login or password");
        }

        string token = JwtHandler.CreateToken(student);
        studentDto = new UserDto(student, token);
        return new Result<UserDto?>(true, studentDto, "");
    }

    public static Result<UserDto?> LoginTutor(UserDto studentDto)
    {
        var student = _context.Tutors.FirstOrDefault(x => x.Login == studentDto.Login);
        if (student is null) { return new Result<UserDto?>(false, null, "Wrong login or password"); }

        if (!BCrypt.Net.BCrypt.Verify(studentDto.Password + student.PasswordSalt, student.PasswordHash))
        {
            return new Result<UserDto?>(false, null, "Wrong login or password");
        }

        string token = JwtHandler.CreateToken(student);
        studentDto = new UserDto(student, token);
        return new Result<UserDto?>(true, studentDto, "");
    }

    public static Result<UserDto?> RegisterStudent(UserDto studentDto)
    {
        lock (_context)
        {
            if (_context.Students.FirstOrDefault(x => x.Login == studentDto.Login) != default)
            {
                return new Result<UserDto?>(false, null, "User with this login already exists");
            }
        }

        Student student = new(passwordSalt: BCrypt.Net.BCrypt.GenerateSalt())
        {
            Login = studentDto.Login,
            LastName = studentDto.LastName,
            FirstName = studentDto.FirstName,
        };
        student.PasswordHash = BCrypt.Net.BCrypt.HashPassword(studentDto.Password + student.PasswordSalt, workFactor: 13);

        try
        {
            lock (_context)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            return new Result<UserDto?>(false, null, ex.Message);
        }

        string token = JwtHandler.CreateToken(student);
        studentDto = new UserDto(student, token);
        return new Result<UserDto?>(true, studentDto, "");
    }

    public static Result<UserDto?> RegisterTutor(UserDto tutorDto)
    {
        lock (_context)
        {
            if (_context.Tutors.FirstOrDefault(x => x.Login == tutorDto.Login) != default)
            {
                return new Result<UserDto?>(false, null, "User with this login already exists");
            }
        }

        Tutor tutor = new(passwordSalt: BCrypt.Net.BCrypt.GenerateSalt())
        {
            Login = tutorDto.Login,
            LastName = tutorDto.LastName,
            FirstName = tutorDto.FirstName,
            Schedule = new EFBoolCollection()

        };
        tutor.PasswordHash = BCrypt.Net.BCrypt.HashPassword(tutorDto.Password + tutor.PasswordSalt, workFactor: 13);

        try
        {
            lock (_context)
            {
                _context.Tutors.Add(tutor);
                _context.SaveChanges();
            }
        }
        catch (Exception ex) { return new Result<UserDto?>(false, null, ex.Message); }

        string token = JwtHandler.CreateToken(tutor);
        tutorDto = new UserDto(tutor, token);
        return new Result<UserDto?>(true, tutorDto, "");
    }

    //public static Result<StudentDto?> Login(StudentDto studentDto)
    //{
    //    var tutor = _context.Students.FirstOrDefault(x => x.Login == studentDto.Login);
    //    if (tutor is null) { return new Result<StudentDto?>(false, null, "Wrong login or password"); }

    //    if (!BCrypt.Net.BCrypt.Verify(studentDto.Password + tutor.PasswordSalt, tutor.PasswordHash))
    //    {
    //        return new Result<StudentDto?>(false, null, "Wrong login or password");
    //    }

    //    string token = JwtHandler.CreateToken(tutor);
    //    studentDto = new StudentDto(tutor)
    //    {
    //        JwtToken = token
    //    };
    //    return new Result<StudentDto?>(true, studentDto, "");
    //}

    //public static Result<TutorDto?> Login(TutorDto studentDto)
    //{
    //    var tutor = _context.Tutors.FirstOrDefault(x => x.Login == studentDto.Login);
    //    if (tutor is null) { return new Result<TutorDto?>(false, null, "Wrong login or password"); }

    //    if (!BCrypt.Net.BCrypt.Verify(studentDto.Password + tutor.PasswordSalt, tutor.PasswordHash))
    //    {
    //        return new Result<TutorDto?>(false, null, "Wrong login or password");
    //    }

    //    string token = JwtHandler.CreateToken(tutor);
    //    studentDto = new TutorDto(tutor)
    //    {
    //        JwtToken = token
    //    };
    //    return new Result<TutorDto?>(true, studentDto, "");
    //}

    //public static Result<AdminDto?> Login(AdminDto adminDto)
    //{
    //    var admin = _context.Admins.FirstOrDefault(x => x.Login == adminDto.Login);
    //    if (admin is null) { return new Result<AdminDto?>(false, null, "Wrong login or password"); }

    //    if (!BCrypt.Net.BCrypt.Verify(adminDto.Password + admin.PasswordSalt, admin.PasswordHash))
    //    {
    //        return new Result<AdminDto?>(false, null, "Wrong login or password");
    //    }

    //    string token = JwtHandler.CreateToken(admin);
    //    adminDto = new AdminDto(admin)
    //    {
    //        JwtToken = token
    //    };
    //    return new Result<AdminDto?>(true, adminDto, "");
    //}

    //public static Result<StudentDto?> Register(StudentDto studentDto)
    //{
    //    lock (_context)
    //    {
    //        if (_context.Students.FirstOrDefault(x => x.Login == studentDto.Login) != default)
    //        {
    //            return new Result<StudentDto?>(false, null, "User with this login already exists");
    //        }
    //    }

    //    Student tutor = new(passwordSalt: BCrypt.Net.BCrypt.GenerateSalt())
    //    {
    //        PhoneNumber = studentDto.PhoneNumber,
    //        Login = studentDto.Login,
    //        LastName = studentDto.LastName,
    //        FirstName = studentDto.FirstName,
    //    };
    //    tutor.PasswordHash = BCrypt.Net.BCrypt.HashPassword(studentDto.Password + tutor.PasswordSalt, workFactor: 13);

    //    try
    //    {
    //        lock (_context)
    //        {
    //            _context.Students.Add(tutor);
    //            _context.SaveChanges();
    //        }
    //    }
    //    catch (Exception ex) { return new Result<StudentDto?>(false, null, ex.Message); }

    //    string token = JwtHandler.CreateToken(tutor);
    //    studentDto = new StudentDto(tutor)
    //    {
    //        JwtToken = token
    //    };
    //    return new Result<StudentDto?>(true, studentDto, "");
    //}

    //public static Result<TutorDto?> Register(TutorDto studentDto)
    //{
    //    lock (_context)
    //    {
    //        if (_context.Tutors.FirstOrDefault(x => x.Login == studentDto.Login) != default)
    //        {
    //            return new Result<TutorDto?>(false, null, "User with this login already exists");
    //        }
    //    }
    //    if (studentDto.Experience is null
    //        || studentDto.Gender is null
    //        || studentDto.AgeGroup is null) return new Result<TutorDto?>(false, null, "Tutor experience was null");

    //    Tutor tutor = new(passwordSalt: BCrypt.Net.BCrypt.GenerateSalt())
    //    {
    //        Experience = (Experience)studentDto.Experience,
    //        Email = studentDto.Email,
    //        PhoneNumber = studentDto.PhoneNumber,
    //        Viber = studentDto.Viber,
    //        Telegram = studentDto.Telegram,
    //        Login = studentDto.Login,
    //        LastName = studentDto.LastName,
    //        FirstName = studentDto.FirstName,
    //        ShortDescription = studentDto.ShortDescription,
    //        LongDescription = studentDto.LongDescription,
    //        AgeGroup = (AgeGroup)studentDto.AgeGroup,
    //        Gender = (Gender)studentDto.Gender,
    //        Schedule = new EFBoolCollection()

    //    };
    //    tutor.PasswordHash = BCrypt.Net.BCrypt.HashPassword(studentDto.Password + tutor.PasswordSalt, workFactor: 13);

    //    tutor.Login = studentDto.Login;

    //    try
    //    {
    //        lock (_context)
    //        {
    //            _context.Tutors.Add(tutor);
    //            _context.SaveChanges();
    //        }
    //    }
    //    catch (Exception ex) { return new Result<TutorDto?>(false, null, ex.Message); }

    //    string token = JwtHandler.CreateToken(tutor);
    //    studentDto = new TutorDto(tutor)
    //    {
    //        JwtToken = token
    //    };
    //    return new Result<TutorDto?>(true, studentDto, "");
    //}

    //public static Result<AdminDto?> Register(AdminDto adminDto)
    //{
    //    lock (_context)
    //    {
    //        if (_context.Admins.FirstOrDefault(x => x.Login == adminDto.Login) != default)
    //        {
    //            return new Result<AdminDto?>(false, null, "User with this login already exists");
    //        }
    //    }

    //    Admin admin = new(passwordSalt: BCrypt.Net.BCrypt.GenerateSalt())
    //    {
    //        Login = adminDto.Login,
    //        LastName = adminDto.LastName,
    //        FirstName = adminDto.FirstName,
    //    };
    //    admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminDto.Password + admin.PasswordSalt, workFactor: 13);

    //    admin.Login = adminDto.Login;

    //    try
    //    {
    //        lock (_context)
    //        {
    //            _context.Admins.Add(admin);
    //            _context.SaveChanges();
    //        }
    //    }
    //    catch (Exception ex) { return new Result<AdminDto?>(false, null, ex.Message); }

    //    string token = JwtHandler.CreateToken(admin);
    //    adminDto = new AdminDto(admin)
    //    {
    //        JwtToken = token
    //    };
    //    return new Result<AdminDto?>(true, adminDto, "");
    //}
}
