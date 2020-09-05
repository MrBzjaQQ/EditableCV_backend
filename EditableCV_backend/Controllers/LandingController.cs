using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EditableCV_backend.Data.LandingData;
using EditableCV_backend.DataTransferObjects.LandingDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
  [Route("api/landing")]
  [ApiController]
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
