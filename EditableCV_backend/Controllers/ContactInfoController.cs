using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EditableCV_backend.Data.ContactInfoData;
using EditableCV_backend.Data.ContactInfoDto;
using EditableCV_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
  [Route("api/contact-info")]
  [ApiController]
  public class ContactInfoController : ControllerBase
  {
    public ContactInfoController(IContactInfoRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    [HttpGet]
    public ActionResult<ContactInfoReadDto> GetContactInfo()
    {
      var info = _repository.GetContactInfo();
      if (info == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<ContactInfoReadDto>(info));
    }

    [HttpPut]
    public ActionResult PutContactInfo(ContactInfoUpdateDto updateInfoDto)
    {
      var info = _repository.GetContactInfo();
      if (info == null)
      {
        var mappedInfo = _mapper.Map<ContactInfo>(updateInfoDto);
        _repository.AddContactInfo(mappedInfo);
        _repository.SaveChanges();
        return NoContent();
      }
      var updatedInfo = _mapper.Map(updateInfoDto, info);
      _repository.UpdateContactInfo(updatedInfo);
      _repository.SaveChanges();
      return NoContent();
    }

    private readonly IContactInfoRepository _repository;
    private readonly IMapper _mapper;
  }
}
