using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Models
{
  public class WorkPlace
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string Position { get; set; }
    public string Experience { get; set; }
    [Required]
    public DateTime StartWorkingTime { get; set; }
    [Required]
    public bool IsCurrentlyWorking { get; set; }
    [Required]
    public DateTime EndWorkingTime { get; set; }
    public byte[] CompanyIcon { get; set; }

  }
}
