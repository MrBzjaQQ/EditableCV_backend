using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.DataTransferObjects.SkillDto
{
  public class SkillReadDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
