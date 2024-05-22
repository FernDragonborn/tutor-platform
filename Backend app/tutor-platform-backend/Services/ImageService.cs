using LittlePictureNetworkBackend.Interfaces;
using Microsoft.IdentityModel.Tokens;
using TutorPlatformBackend.DbContext;
using TutorPlatformBackend.DTOs;
using TutorPlatformBackend.ImageConvertors;
using TutorPlatformBackend.Interfaces;
using TutorPlatformBackend.Models;

namespace TutorPlatformBackend.Services;
public class ImageService : IDisposable
{
    private readonly TutorPlatformDbContext _context;
    private readonly IVirusScanner _virusScanner;
    private readonly IImageConverter _imageConverter;

    public ImageService(TutorPlatformDbContext context, IVirusScanner virusScanner, IImageConverter photoConverter)
    {
        _context = context;
        _virusScanner = virusScanner;
        _imageConverter = photoConverter;
    }

    private Result<MyImage?> ProcessImage(ImageDto imageDto)
    {
        if (imageDto.ImageData.IsNullOrEmpty()) { return new Result<MyImage?>(false, null, "ImageData was empty."); }

        MyImage image = new(
            Guid.Parse(imageDto.TutorId),
            _imageConverter.ToByteArray(imageDto.ImageData)
            );


        bool noViruses = _virusScanner.ScanPhotoForViruses(image.ImageData);
        if (!noViruses) { return new Result<MyImage?>(false, null, "MyImage contains viruses."); }

        image.ImageData = _imageConverter.ToJpeg(image.ImageData);

        return new Result<MyImage?>(true, image, "");
    }

    public Result UpdateTutorPhoto(ImageDto ImageDto)
    {
        var result = ProcessImage(ImageDto);
        if (result.IsSuccess)
        {
            lock (_context.Tutors)
            {
                var tutor = _context.Tutors.Find(result.Data.TutorId);
                tutor.ProfilePic = result.Data.ImageData;
                _context.Tutors.Update(tutor);
                _context.SaveChanges();
                return new Result(true, "");
            }
        }
        return new Result(false, result.Message);
    }

    public Result AddTutorEducationDocumentPhoto(ImageDto ImageDto)
    {
        var result = ProcessImage(ImageDto);
        if (result.IsSuccess)
        {
            lock (_context.Tutors)
            {
                var tutor = _context.Tutors.Find(result.Data.TutorId);
                var document = new EducationDocument(result.Data.TutorId, result.Data.ImageType, result.Data.ImageData);
                if (tutor.EducationDocuments.Count >= 5)
                    return new Result(false, $"To many education documents, not more than 5 could be uploaded");
                tutor.EducationDocuments.Add(document);
                _context.Tutors.Update(tutor);
                _context.SaveChanges();
                return new Result(true, "");
            }
        }
        return new Result(false, result.Message);
    }

    public Result DeleteTutorEducationDocument(string TutorId, string DocumentId)
    {
        if (!Guid.TryParse(TutorId, out Guid tutorGuid)) return new Result(false, "tutorId format not suitable for Guid");
        if (!Guid.TryParse(DocumentId, out Guid DocumentGuid)) return new Result(false, "documentId format not suitable for Guid");
        var tutor = _context.Tutors.Find(tutorGuid);
        if (tutor is null) return new Result(false, "tutor with this Id doesn't exist");
        bool isSuccess;
        try
        {
            isSuccess = tutor.EducationDocuments.Remove(
                tutor.EducationDocuments.FirstOrDefault(doc => doc.Id == DocumentGuid)
            );
        }
        catch (Exception ex) { return new Result(false, ex.Message); }

        if (!isSuccess) return new Result(false, "No document with this Id");
        _context.Tutors.Update(tutor);
        _context.SaveChanges();
        return new Result(true, "");
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

