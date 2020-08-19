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

    private readonly ResumeContext _context;

    public IEnumerable<WorkPlace> GetAllWorkPlaces()
    {
      return _context.WorkPlaces.ToList();
    }

    public WorkPlace GetWorkPlaceById(int id)
    {
      return _context.WorkPlaces.FirstOrDefault(item => item.Id == id);
    }
  }
}
