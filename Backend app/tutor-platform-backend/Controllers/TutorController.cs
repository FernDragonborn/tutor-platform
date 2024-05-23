using Microsoft.AspNetCore.Mvc;
using TutorPlatformBackend.DbContext;

namespace TutorPlatformBackend.Controllers;

public class TutorController : Controller
{
    private readonly TutorPlatformDbContext _context;

    public TutorController(TutorPlatformDbContext context)
    {
        _context = context;
    }


}
