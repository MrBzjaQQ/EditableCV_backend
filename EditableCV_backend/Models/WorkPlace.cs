using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Models
{
  public class WorkPlace
  {
    public WorkPlace() { }
    public WorkPlace(WorkPlace place)
    {
      Id = place.Id;
      CompanyName = place.CompanyName;
      Position = place.Position;
      Experience = place.Experience;
      StartWorkingDate = place.StartWorkingDate;
      EndWorkingDate = place.EndWorkingDate;
    }
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(250)]
    public string CompanyName { get; set; }
    [Required]
    [MaxLength(250)]
    public string Position { get; set; }
    public string Experience { get; set; }
    [Required]
    [Column(TypeName = "date")]
    public DateTime StartWorkingDate { get; set; }
    [Required]
    [Column(TypeName = "date")]
    public DateTime EndWorkingDate { get; set; }
    [NotMapped]
    public bool IsValid
    {
      get
      {
        bool isValid = true;
        if(CompanyName == null || CompanyName == string.Empty)
        {
          isValid = false;
        }
        if (Position == null || Position == string.Empty)
        {
          isValid = false;
        }
        if (DateTime.MinValue.CompareTo(StartWorkingDate) == 0)
        {
          isValid = false;
        }
        if (DateTime.MinValue.CompareTo(EndWorkingDate) == 0)
        {
          isValid = false;
        }
        if (EndWorkingDate.CompareTo(StartWorkingDate) < 0)
        {
          isValid = false;
        }
        return isValid;
      }
    }
  }
}
