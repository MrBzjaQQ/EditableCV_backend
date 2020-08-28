using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data
{
  public interface IRepository
  {
    bool SaveChanges();
  }
}
