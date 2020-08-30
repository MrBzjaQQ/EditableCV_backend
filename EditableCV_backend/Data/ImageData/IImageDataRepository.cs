using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.ImageData
{
  interface IImageDataRepository: IRepository
  {
    void CreateImage(ImageModel image);
    void DeleteImage(ImageModel image);
    void UpdateImage(ImageModel image);
    ImageModel GetImageById(int id);
    IEnumerable<ImageModel> GetAllImages();
  }
}
