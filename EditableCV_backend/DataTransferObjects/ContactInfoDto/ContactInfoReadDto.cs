using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.ContactInfoDto
{
  public class ContactInfoReadDto
  {
    public int Id { get; set; }
    public string Phone { get; set; }
    public string VK { get; set; }
    public string Skype { get; set; }
    public string Instagram { get; set; }
    public string YouTube { get; set; }
    public string LinkedIn { get; set; }
    public string Facebook { get; set; }
  }
}
