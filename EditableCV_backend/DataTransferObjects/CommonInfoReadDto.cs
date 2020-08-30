using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.DataTransferObjects
{
  public class CommonInfoReadDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PartonymicName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ImageModel Photo { get; set; }
  }
}
