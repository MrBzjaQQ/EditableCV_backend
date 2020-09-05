using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data.ContactInfoData
{
  public interface IContactInfoRepository: IRepository
  {
    ContactInfo GetContactInfo();
    void UpdateContactInfo(ContactInfo info);
    void AddContactInfo(ContactInfo info);
  }
}
