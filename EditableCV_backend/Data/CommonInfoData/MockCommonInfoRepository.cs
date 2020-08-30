using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.CommonInfoData
{
  public class MockCommonInfoRepository : ICommonInfoRepository
  {
    public void AddCommonInfo(CommonInfo info)
    {
      if (_commonInfo == null)
      {
        _commonInfo = new CommonInfo(info);
      }
    }

    public CommonInfo GetCommonInfo()
    {
      return _savedCommonInfo;
    }

    public bool SaveChanges()
    {
      if (_commonInfo == null)
      {
        return false;
      }
      _savedCommonInfo = new CommonInfo(_commonInfo);
      return true;
    }

    public void UpdateCommonInfo(CommonInfo info)
    {
      _commonInfo = new CommonInfo(info);
    }

    private CommonInfo _commonInfo;
    private CommonInfo _savedCommonInfo;
  }
}
