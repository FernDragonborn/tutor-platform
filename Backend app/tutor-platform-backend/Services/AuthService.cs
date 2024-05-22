using TutorPlatformBackend.DbContext;
using TutorPlatformBackend.DTOs;
using TutorPlatformBackend.Enums;
using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.Services;

public static class AuthService
{
    private static readonly TutorPlatformDbContext _context;
    static AuthService()
    {
        _context = ContextFactory.CreateNew();
    }

    public static Result<StudentDto?> Login(StudentDto studentDto)
    {
        var student = _context.Students.FirstOrDefault(x => x.Login == studentDto.Login);
        if (student is null) { return new Result<StudentDto?>(false, null, "Wrong login or password"); }

        if (!BCrypt.Net.BCrypt.Verify(studentDto.Password + student.PasswordSalt, student.PasswordHash))
        {
            return new Result<StudentDto?>(false, null, "Wrong login or password");
        }

        string token = JwtHandler.CreateToken(student);
        studentDto = new StudentDto(student)
        {
            JwtToken = token
        };
        return new Result<StudentDto?>(true, studentDto, "");
    }

    public static Result<TutorDto?> Login(TutorDto tutorDto)
    {
        var tutor = _context.Tutors.FirstOrDefault(x => x.Login == tutorDto.Login);
        if (tutor is null) { return new Result<TutorDto?>(false, null, "Wrong login or password"); }

        if (!BCrypt.Net.BCrypt.Verify(tutorDto.Password + tutor.PasswordSalt, tutor.PasswordHash))
        {
            return new Result<TutorDto?>(false, null, "Wrong login or password");
        }

        string token = JwtHandler.CreateToken(tutor);
        tutorDto = new TutorDto(tutor)
        {
            JwtToken = token
        };
        return new Result<TutorDto?>(true, tutorDto, "");
    }

    public static Result<AdminDto?> Login(AdminDto adminDto)
    {
        var admin = _context.Admins.FirstOrDefault(x => x.Login == adminDto.Login);
        if (admin is null) { return new Result<AdminDto?>(false, null, "Wrong login or password"); }

        if (!BCrypt.Net.BCrypt.Verify(adminDto.Password + admin.PasswordSalt, admin.PasswordHash))
        {
            return new Result<AdminDto?>(false, null, "Wrong login or password");
        }

        string token = JwtHandler.CreateToken(admin);
        adminDto = new AdminDto(admin)
        {
            JwtToken = token
        };
        return new Result<AdminDto?>(true, adminDto, "");
    }

    public static Result<StudentDto?> Register(StudentDto studentDto)
    {
        lock (_context)
        {
            if (_context.Students.FirstOrDefault(x => x.Login == studentDto.Login) != default)
            {
                return new Result<StudentDto?>(false, null, "User with this login already exists");
            }
        }

        Student student = new(passwordSalt: BCrypt.Net.BCrypt.GenerateSalt())
        {
            PhoneNumber = studentDto.PhoneNumber,
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
        catch (Exception ex) { return new Result<StudentDto?>(false, null, ex.Message); }

        string token = JwtHandler.CreateToken(student);
        studentDto = new StudentDto(student)
        {
            JwtToken = token
        };
        return new Result<StudentDto?>(true, studentDto, "");
    }

    public static Result<TutorDto?> Register(TutorDto tutorDto)
    {
        lock (_context)
        {
            if (_context.Tutors.FirstOrDefault(x => x.Login == tutorDto.Login) != default)
            {
                return new Result<TutorDto?>(false, null, "User with this login already exists");
            }
        }
        if (tutorDto.Experience is null
            || tutorDto.Gender is null
            || tutorDto.AgeGroup is null) return new Result<TutorDto?>(false, null, "Tutor experience was null");

        Tutor tutor = new(passwordSalt: BCrypt.Net.BCrypt.GenerateSalt())
        {
            Experience = (Experience)tutorDto.Experience,
            Email = tutorDto.Email,
            PhoneNumber = tutorDto.PhoneNumber,
            Viber = tutorDto.Viber,
            Telegram = tutorDto.Telegram,
            Login = tutorDto.Login,
            LastName = tutorDto.LastName,
            FirstName = tutorDto.FirstName,
            ShortDescription = tutorDto.ShortDescription,
            DetailedDescription = tutorDto.DetailedDescription,
            AgeGroup = (AgeGroup)tutorDto.AgeGroup,
            Gender = (Gender)tutorDto.Gender,
            Schedule = new EFBoolCollection()

        };
        tutor.PasswordHash = BCrypt.Net.BCrypt.HashPassword(tutorDto.Password + tutor.PasswordSalt, workFactor: 13);

        tutor.Login = tutorDto.Login;
        tutor.Role = tutorDto.Role;

        try
        {
            lock (_context)
            {
                _context.Tutors.Add(tutor);
                _context.SaveChanges();
            }
        }
        catch (Exception ex) { return new Result<TutorDto?>(false, null, ex.Message); }

        string token = JwtHandler.CreateToken(tutor);
        tutorDto = new TutorDto(tutor)
        {
            JwtToken = token
        };
        return new Result<TutorDto?>(true, tutorDto, "");
    }

    public static Result<AdminDto?> Register(AdminDto adminDto)
    {
        lock (_context)
        {
            if (_context.Admins.FirstOrDefault(x => x.Login == adminDto.Login) != default)
            {
                return new Result<AdminDto?>(false, null, "User with this login already exists");
            }
        }

        Admin admin = new(passwordSalt: BCrypt.Net.BCrypt.GenerateSalt())
        {
            Login = adminDto.Login,
            LastName = adminDto.LastName,
            FirstName = adminDto.FirstName,
        };
        admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminDto.Password + admin.PasswordSalt, workFactor: 13);

        admin.Login = adminDto.Login;
        admin.Role = adminDto.Role;

        try
        {
            lock (_context)
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
            }
        }
        catch (Exception ex) { return new Result<AdminDto?>(false, null, ex.Message); }

        string token = JwtHandler.CreateToken(admin);
        adminDto = new AdminDto(admin)
        {
            JwtToken = token
        };
        return new Result<AdminDto?>(true, adminDto, "");
    }
}
