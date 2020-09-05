using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.DataTransferObjects.SkillDto
{
  public class SkillCreateDto
  {
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
