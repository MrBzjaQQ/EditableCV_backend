using AutoMapper;
using EditableCV_backend.Controllers;
using EditableCV_backend.Data.CommonInfoData;
using EditableCV_backend.Data.WorkPlaceData;
using EditableCV_backend.DataTransferObjects;
using EditableCV_backend.DataTransferObjects.CommonInfoDto;
using EditableCV_backend.Models;
using EditableCV_backend.Profiles;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Moq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace EditableCV_backend.Test
{
  public class CommonInfoControllerTests
  {
    public CommonInfoControllerTests()
    {
      _repo = new MockCommonInfoRepository();
      _profile = new ResumeProfile();
      _config = new MapperConfiguration(p => p.AddProfile(_profile));
      _mapper = new Mapper(_config);
      var mockValidator = new Mock<IObjectModelValidator>();
      mockValidator.Setup(o => o.Validate(
        It.IsAny<ActionContext>(),
        It.IsAny<ValidationStateDictionary>(),
        It.IsAny<string>(),
        It.IsAny<object>()
      ));
      _controller = new CommonInfoController(_repo, _mapper)
      {
        ObjectValidator = mockValidator.Object,
      };
    }

    [Fact]
    public void GetCurrentInfo_ShouldReturnNotFound()
    {
      // Arrange & Act
      var response = _controller.GetCommonInfo();
      // Assert
      var commonInfoReadDto = Assert.IsType<NotFoundResult>(response.Result);
    }

    [Fact]
    public void PutAndGetInfo_ShoundReturnNoContentForPut_And_ShouldReturnDataForGet()
    {
      // Arrange
      CommonInfoCreateDto dto = new CommonInfoCreateDto
      {
        FirstName = "FirstName",
        LastName = "LastName",
        PatronymicName = "PatronymicName",
        DateOfBirth = new DateTime(2000, 1, 1),
      };
      // Act
      var putResult = _controller.PutCommonInfo(dto);
      // Assert
      Assert.IsType<NoContentResult>(putResult);
      // Act
      var getResult = _controller.GetCommonInfo();
      //Assert
      var okResult = Assert.IsType<OkObjectResult>(getResult.Result);
      CommonInfoReadDto info = Assert.IsType<CommonInfoReadDto>(okResult.Value);
      Assert.Equal(dto.FirstName, info.FirstName);
      Assert.Equal(dto.LastName, info.LastName);
      Assert.Equal(dto.PatronymicName, info.PatronymicName);
      Assert.Equal(dto.DateOfBirth.Year, info.DateOfBirth.Year);
      Assert.Equal(dto.DateOfBirth.Month, info.DateOfBirth.Month);
      Assert.Equal(dto.DateOfBirth.Day, info.DateOfBirth.Day);
    }

    private MockCommonInfoRepository _repo;
    private ResumeProfile _profile;
    private MapperConfiguration _config;
    private Mapper _mapper;
    private CommonInfoController _controller;
  }
}
