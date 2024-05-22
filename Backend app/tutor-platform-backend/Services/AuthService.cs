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

        Student student = new()
        {
            PasswordSalt = BCrypt.Net.BCrypt.GenerateSalt()
        };
        student.PasswordHash = BCrypt.Net.BCrypt.HashPassword(studentDto.Password + student.PasswordSalt, workFactor: 13);

        student.Login = studentDto.Login;
        student.Role = studentDto.Role;

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

        Tutor tutor = new()
        {
            PasswordSalt = BCrypt.Net.BCrypt.GenerateSalt()
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

    public static Result<AdminDto?> Register(AdminDto AdminDto)
    {
        lock (_context)
        {
            if (_context.Admins.FirstOrDefault(x => x.Login == AdminDto.Login) != default)
            {
                return new Result<AdminDto?>(false, null, "User with this login already exists");
            }
        }

        Admin admin = new()
        {
            PasswordSalt = BCrypt.Net.BCrypt.GenerateSalt()
        };
        admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(AdminDto.Password + admin.PasswordSalt, workFactor: 13);

        admin.Login = AdminDto.Login;
        admin.Role = AdminDto.Role;

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
        AdminDto = new AdminDto(admin)
        {
            JwtToken = token
        };
        return new Result<AdminDto?>(true, AdminDto, "");
    }
}
