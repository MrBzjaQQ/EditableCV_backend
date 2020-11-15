using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Exceptions.Auth
{
  public class UserNotFoundException: Exception
  {
    public UserNotFoundException() : base("User not found or not exists.")
    {

    }
  }
}
