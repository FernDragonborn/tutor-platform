namespace TutorPlatformBackend.Interfaces;

public interface IPhotoScaler
{
    byte[] ConvertToJpeg(byte[] photoData);
}
