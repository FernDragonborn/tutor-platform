using System.Drawing;
using System.Drawing.Imaging;
using TutorPlatformBackend.Interfaces;

namespace TutorPlatformBackend.ImageConvertors;

public class SimplmageConverter : IImageConverter
{

    public byte[] ToByteArray(string imageDataStr)
    {
        //I know that this isn't right, but Convert.FromBase64String haven't warked. I'm in search how to fix this
        var stringArr = imageDataStr.Split(',');
        byte[] photoDataByte = stringArr.Select(str => Convert.ToByte(str))
            .ToArray();
        return photoDataByte;
    }

    public byte[] ToJpeg(byte[] imageData)
    {
        var ms = new MemoryStream(imageData);
        string path = @"D:\data\temp.jpeg";
        FileStream fs = new(path, FileMode.Create, FileAccess.ReadWrite);
        fs.Write(imageData);
        fs.Close();
        byte[] resposePhotoData = null;
        using (Bitmap bmp = new(path))
        {
            bmp.Save(ms, ImageFormat.Jpeg);

            ImageConverter converter = new ImageConverter();
            resposePhotoData = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }

        //TODO I'm not sure, maybe I can use await here for optimization
        ms.Dispose();
        fs.Dispose();

        return resposePhotoData;
    }
}
