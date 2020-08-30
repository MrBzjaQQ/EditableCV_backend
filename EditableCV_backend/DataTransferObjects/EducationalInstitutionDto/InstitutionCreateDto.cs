using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.DataTransferObjects.EducationalInstitutionDto
{
  public class InstitutionCreateDto
  {
    [Required]
    public string Institution { get; set; }
    public string Faculty { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    public string Progress { get; set; }
  }
}
