using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Models
{
  public class Skill
  {
    public Skill() { }
    public Skill(Skill skill)
    {
      Id = skill.Id;
      Name = skill.Name;
      Description = skill.Description;
    }
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [NotMapped]
    public bool IsValid
    {
      get
      {
        bool isValid = true;
        if (Name == null || Name == string.Empty)
        {
          isValid = false;
        }
        return isValid;
      }
    }
  }
}
