using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.CommonInfoData
{
  public interface ICommonInfoRepository : IRepository
  {
    CommonInfo GetCommonInfo();
    void UpdateCommonInfo(CommonInfo info);
    void AddCommonInfo(CommonInfo info);
  }
}
