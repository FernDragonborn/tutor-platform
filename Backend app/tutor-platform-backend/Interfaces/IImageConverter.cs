namespace TutorPlatformBackend.Interfaces;

public interface IImageConverter
{
    byte[] ToJpeg(byte[] imageData);
    byte[] ToByteArray(string imageDataStr);
}
