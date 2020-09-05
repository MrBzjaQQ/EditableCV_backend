using EditableCV_backend.Data.ContactInfoDto;
using EditableCV_backend.DataTransferObjects.CommonInfoDto;
using EditableCV_backend.DataTransferObjects.EducationalInstitutionDto;
using EditableCV_backend.DataTransferObjects.SkillDto;
using EditableCV_backend.DataTransferObjects.WorkPlaceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.DataTransferObjects.LandingDto
{
  public class LandingReadDto
  {
    public CommonInfoReadLandingDto CommonInfo { get; set; }
    public ContactInfoReadDto ContactInfo { get; set; }
    public IEnumerable<WorkPlaceReadDto> WorkPlaces { get; set; }
    public IEnumerable<InstitutionReadDto> Education { get; set; }
    public IEnumerable<SkillReadDto> Skills { get; set; }
  }
}
