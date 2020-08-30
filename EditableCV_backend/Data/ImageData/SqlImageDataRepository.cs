using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.ImageData
{
  public class SqlImageDataRepository : IImageDataRepository
  {
    public SqlImageDataRepository(ResumeContext context)
    {
      _context = context;
    }
    public void CreateImage(ImageModel image)
    {
      _context.Images.Add(image);
    }

    public void DeleteImage(ImageModel image)
    {
      _context.Images.Remove(image);
    }

    public IEnumerable<ImageModel> GetAllImages()
    {
      return _context.Images.ToList();
    }

    public ImageModel GetImageById(int id)
    {
      return _context.Images.FirstOrDefault(img => img.Id == id);
    }

    public bool SaveChanges()
    {
      return _context.SaveChanges() >= 0;
    }

    public void UpdateImage(ImageModel image)
    {
       // Nothing here
    }
    private ResumeContext _context;
  }
}
