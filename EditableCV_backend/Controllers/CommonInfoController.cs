using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EditableCV_backend.Data.CommonInfoData;
using EditableCV_backend.DataTransferObjects;
using EditableCV_backend.DataTransferObjects.CommonInfoDto;
using EditableCV_backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
  [Route("api/common-info")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [ApiController]
  public class CommonInfoController : ControllerBase
  {
    public CommonInfoController(ICommonInfoRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<CommonInfoReadDto> GetCommonInfo()
    {
      var commonInfo = _repository.GetCommonInfo();
      if (commonInfo == null)
      {
        return NotFound();
      }
      var commonInfoDto = _mapper.Map<CommonInfoReadDto>(commonInfo);
      return Ok(commonInfoDto);
    }

    [HttpPut]
    public ActionResult PutCommonInfo(CommonInfoCreateDto info)
    {
      var commonInfo = _repository.GetCommonInfo();
      if (commonInfo == null)
      {
        var mappedInfo = _mapper.Map<CommonInfo>(info);
        _repository.AddCommonInfo(mappedInfo);
        _repository.SaveChanges();
        return NoContent();
      }
      var updatedInfo = _mapper.Map(info, commonInfo);
      // does nothing for current implementation, but nessesary if implementation would change
      _repository.UpdateCommonInfo(updatedInfo);
      _repository.SaveChanges();
      return NoContent();
    }

    private ICommonInfoRepository _repository;
    private IMapper _mapper;
  }
}
