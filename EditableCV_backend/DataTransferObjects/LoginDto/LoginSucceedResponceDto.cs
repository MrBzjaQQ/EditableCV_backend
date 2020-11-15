using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.DataTransferObjects.LoginDto
{
  public class LoginSucceedResponceDto
  {
    public string AccessToken { get; set; }
    public string Email { get; set; }
  }
}
