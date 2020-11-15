using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditableCV_backend.Options.Tokens
{
  public class AuthOptions
  {
    public const string ISSUER = "Resume API Server";
    public const string AUDIENCE = "Resume API Client";
    public const int LIFETIME = 25200;
    public const string TOKEN_NAME = "AuthenticationToken";
    const string KEY = "pa55word_secretkey!123";
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
      return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
  }
}
