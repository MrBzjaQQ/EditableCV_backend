using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.ContactInfoData
{
  public class MockContactInfoRepository : IContactInfoRepository
  {
    public void AddContactInfo(ContactInfo info)
    {
      if (_info == null)
      {
        _info = new ContactInfo(info);
      }
    }

    public ContactInfo GetContactInfo()
    {
      return _savedInfo;
    }

    public bool SaveChanges()
    {
      _savedInfo = new ContactInfo(_info);
      return true;
    }

    public void UpdateContactInfo(ContactInfo info)
    {
      _info = new ContactInfo(info);
    }

    private ContactInfo _info;
    private ContactInfo _savedInfo;
  }
}
