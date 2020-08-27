using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data
{
  public class SqlWorkPlaceRepository : IWorkPlaceRepository
  {
    public SqlWorkPlaceRepository(ResumeContext context)
    {
      _context = context;
    }

    public IEnumerable<WorkPlace> GetAllWorkPlaces()
    {
      return _context.WorkPlaces.ToList();
    }

    public WorkPlace GetWorkPlaceById(int id)
    {
      return _context.WorkPlaces.FirstOrDefault(item => item.Id == id);
    }

    public bool SaveChanges()
    {
      return _context.SaveChanges() >= 0;
    }

    public void CreateWorkPlace(WorkPlace place)
    {
      if (place == null)
      {
        throw new ArgumentNullException(nameof(place));
      }
      _context.WorkPlaces.Add(place);
    }

    public void UpdateWorkPlace(WorkPlace place)
    {
      // Nothing here
    }

    public void DeleteWorkPlace(WorkPlace place)
    {
      if (place == null)
      {
        throw new ArgumentNullException(nameof(place));
      }
      _context.WorkPlaces.Remove(place);
    }

    private readonly ResumeContext _context;
  }
}
