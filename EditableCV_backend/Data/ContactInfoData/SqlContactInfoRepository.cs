using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.ContactInfoData
{
  public class SqlContactInfoRepository : IContactInfoRepository
  {
    public SqlContactInfoRepository(ResumeContext context)
    {
      _context = context;
    }
    public void AddContactInfo(ContactInfo info)
    {
      var currInfo = GetContactInfo();
      if (currInfo == null)
      {
        _context.ContactInfos.Add(info);
      }
    }

    public ContactInfo GetContactInfo()
    {
      return _context.ContactInfos.FirstOrDefault();
    }

    public bool SaveChanges()
    {
      return _context.SaveChanges() >= 0;
    }

    public void UpdateContactInfo(ContactInfo info)
    {
      // Nothing here
    }

    private readonly ResumeContext _context;
  }
}
