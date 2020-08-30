using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.EducationInstitutionData
{
  public interface IEducationRepository: IRepository
  {
    IEnumerable<EducationalInstitution> GetAllInstitutions();
    EducationalInstitution GetInstitutionById(int id);
    void CreateInstitution(EducationalInstitution institution);
    void UpdateInstitution(EducationalInstitution institution);
    void DeleteInstitution(EducationalInstitution institution);
  }
}
