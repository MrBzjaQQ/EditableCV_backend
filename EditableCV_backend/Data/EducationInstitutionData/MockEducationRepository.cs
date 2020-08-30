using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.EducationInstitutionData
{
  public class MockEducationRepository : IEducationRepository
  {
    public MockEducationRepository()
    {
      _institutions = new List<EducationalInstitution>
      {
        new EducationalInstitution
        {
          Id = 1,
          Institution = "Coursera",
          Faculty = "Courses",
          Progress = "a lot",
          StartDate = new DateTime(2020, 06, 06),
          EndDate = new DateTime(2021, 06, 06),
        },
        new EducationalInstitution
        {
          Id = 2,
          Institution = "YouTube",
          Faculty = "Viewer",
          Progress = ":)",
          StartDate = new DateTime(2019, 06, 06),
          EndDate = new DateTime(2020, 06, 06),
        },
      };
      _savedInstitutions = new List<EducationalInstitution>();
      SaveChanges();
    }
    public void CreateInstitution(EducationalInstitution institution)
    {
      if (institution == null)
      {
        throw new ArgumentNullException(nameof(institution));
      }
      _institutions.Add(institution);
    }

    public void DeleteInstitution(EducationalInstitution institution)
    {
      if (institution == null)
      {
        throw new ArgumentNullException(nameof(institution));
      }
      _institutions.Remove(_institutions.FirstOrDefault(item => item.Id == institution.Id));
    }

    public IEnumerable<EducationalInstitution> GetAllInstitutions()
    {
      return new List<EducationalInstitution>(_savedInstitutions);
    }

    public EducationalInstitution GetInstitutionById(int id)
    {
      return _savedInstitutions.FirstOrDefault(item => item.Id == id);
    }

    public bool SaveChanges()
    {
      _savedInstitutions = new List<EducationalInstitution>();
      foreach(var institution in _institutions)
      {
        _savedInstitutions.Add(new EducationalInstitution(institution));
      }
      return true;
    }

    public void UpdateInstitution(EducationalInstitution institution)
    {
      if (institution == null)
      {
        throw new ArgumentNullException(nameof(institution));
      }
      EducationalInstitution savedInstitution = _institutions.FirstOrDefault(item => item.Id == institution.Id);
      if (savedInstitution == null)
      {
        throw new Exception("not found");
      }
      EducationalInstitution updatedInstitution = new EducationalInstitution(institution);
      int index = _institutions.IndexOf(savedInstitution);
      _institutions[index] = updatedInstitution;
    }

    private List<EducationalInstitution> _institutions;
    private List<EducationalInstitution> _savedInstitutions;
  }
}
