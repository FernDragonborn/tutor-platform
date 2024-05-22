using TutorPlatformBackend.Enums;

namespace TutorPlatformBackend.ImageConvertors;

public class MyImage
{
    public MyImage(Guid tutorId, byte[] imageData)
    {
        TutorId = tutorId;
        ImageData = imageData;
    }

    public Guid TutorId { get; set; }
    public ImageType ImageType { get; set; }
    public byte[] ImageData { get; internal set; }
}
