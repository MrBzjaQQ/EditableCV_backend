using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.DataTransferObjects.CommonInfoDto
{
  // For future usage. We don't want to pass the date of birth to our client.
  public class CommonInfoReadLandingDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PatronymicName { get; set; }
    public int Age { get; set; }
    public ImageModel Photo { get; set; }
  }
}
