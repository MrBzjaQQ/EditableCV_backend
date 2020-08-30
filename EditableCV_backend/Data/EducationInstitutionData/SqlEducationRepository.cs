using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.EducationInstitutionData
{
  public class SqlEducationRepository : IEducationRepository
  {
    public SqlEducationRepository(ResumeContext context)
    {
      _context = context;
    }
    public void CreateInstitution(EducationalInstitution institution)
    {
      if (institution == null)
      {
        throw new ArgumentNullException(nameof(institution));
      }
      _context.EducationalInstitutions.Add(institution);
    }

    public void DeleteInstitution(EducationalInstitution institution)
    {
      _context.EducationalInstitutions.Remove(institution);
    }

    public IEnumerable<EducationalInstitution> GetAllInstitutions()
    {
      return _context.EducationalInstitutions.ToList();
    }

    public EducationalInstitution GetInstitutionById(int id)
    {
      return _context.EducationalInstitutions.FirstOrDefault(item => item.Id == id);
    }

    public bool SaveChanges()
    {
      return _context.SaveChanges() > 0;
    }

    public void UpdateInstitution(EducationalInstitution institution)
    {
      // Nothing here
    }
    private ResumeContext _context;
  }
}
