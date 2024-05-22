using TutorPlatformBackend.Enums;

namespace TutorPlatformBackend.DTOs;

public class ImageDto
{
    //recently, only tutors use images
    public string TutorId { get; set; }

    public string ImageData { get; set; }

    public ImageType ImageType { get; set; }

}