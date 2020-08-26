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
    [MaxLength(250)]
    public string CompanyName { get; set; }
    [Required]
    [MaxLength(250)]
    public string Position { get; set; }
    public string Experience { get; set; }
    [Required]
    public DateTime StartWorkingDate { get; set; }
    [Required]
    public DateTime EndWorkingDate { get; set; }
  }
}
