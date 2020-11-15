using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EditableCV_backend.Data.LandingData;
using EditableCV_backend.DataTransferObjects.LandingDto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
  [ApiController]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [Route("api/landing")]
  public class LandingController : ControllerBase
  {
    public LandingController(ILandingDataRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<LandingReadDto> GetLandingData()
    {
      var data = _repository.GetLandingData();
      return Ok(_mapper.Map<LandingReadDto>(data));
    }

    private readonly ILandingDataRepository _repository;
    private readonly IMapper _mapper;
  }
}
