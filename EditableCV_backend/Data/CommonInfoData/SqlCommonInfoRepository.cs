using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.CommonInfoData
{
  public class SqlCommonInfoRepository : ICommonInfoRepository
  {
    public SqlCommonInfoRepository(ResumeContext context)
    {
      _context = context;
    }
    public CommonInfo GetCommonInfo()
    {
      return _context.CommonInfos.FirstOrDefault();
    }

    public bool SaveChanges()
    {
      return _context.SaveChanges() >= 0;
    }

    public void UpdateCommonInfo(CommonInfo info)
    {
      // Nothing here
    }

    public void AddCommonInfo(CommonInfo info)
    {
      var commonInfo = GetCommonInfo();
      if (commonInfo == null)
      {
        _context.Add(info);
      }
    }

    private ResumeContext _context;
  }
}
