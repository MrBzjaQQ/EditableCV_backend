using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.DataTransferObjects
{
  public class WorkPlaceCreateDto
  {
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string Position { get; set; }
    public string Experience { get; set; }
    [Required]
    public DateTime StartWorkingDate { get; set; }
    [Required]
    public DateTime EndWorkingDate { get; set; }
    public byte[] CompanyIcon { get; set; }
  }
}
