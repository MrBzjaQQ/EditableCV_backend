using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Models
{
  public class EducationalInstitution
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Institution { get; set; }
    public string Faculty { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    public string Progress { get; set; }
    [NotMapped]
    public bool IsValid
    {
      get
      {
        bool isValid = true;
        if (Institution == null || Institution == string.Empty)
        {
          isValid = false;
        }
        if (StartDate == null || DateTime.MinValue.CompareTo(StartDate) == 0)
        {
          isValid = false;
        }
        if (EndDate == null || DateTime.MinValue.CompareTo(EndDate) == 0)
        {
          isValid = false;
        }
        if (EndDate.CompareTo(StartDate) < 0)
        {
          isValid = false;
        }
        return isValid;
      }
    }
  }
}
