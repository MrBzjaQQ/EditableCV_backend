using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.DataTransferObjects.CommonInfoDto
{
  public class CommonInfoCreateDto
  {
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string PatronymicName { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    public ImageModel Photo { get; set; }
  }
}
