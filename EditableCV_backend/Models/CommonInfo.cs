using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Models
{
  public class CommonInfo
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string PartonymicName { get; set; }
    public DateTime DateOfBirth { get; set; }
    [ForeignKey("PhotoId")]
    public ImageModel Photo { get; set; }

  }
}
