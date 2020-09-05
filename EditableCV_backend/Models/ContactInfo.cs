using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Models
{
  public class ContactInfo
  {
    public ContactInfo() { }
    public ContactInfo(ContactInfo info)
    {
      Id = info.Id;
      Phone = info.Phone;
      VK = info.VK;
      Skype = info.Skype;
      Instagram = info.Instagram;
      YouTube = info.YouTube;
      LinkedIn = info.LinkedIn;
      Facebook = info.Facebook;
    }
    [Key]
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
