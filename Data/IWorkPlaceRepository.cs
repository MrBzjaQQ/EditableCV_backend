using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data
{
  public interface IWorkPlaceRepository
  {
    IEnumerable<WorkPlace> GetAllWorkPlaces();
    WorkPlace GetWorkPlaceById(int id);
  }
}
