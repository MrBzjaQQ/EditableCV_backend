using AutoMapper;
using EditableCV_backend.DataTransferObjects;
using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Profiles
{
  public class WorkPlacesProfile : Profile
  {
    public WorkPlacesProfile()
    {
      CreateMap<WorkPlace, WorkPlaceReadDto>();
      CreateMap<WorkPlaceCreateDto, WorkPlace>();
    }
  }
}
