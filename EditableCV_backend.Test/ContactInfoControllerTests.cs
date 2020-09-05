using AutoMapper;
using EditableCV_backend.Controllers;
using EditableCV_backend.Data.ContactInfoData;
using EditableCV_backend.Data.ContactInfoDto;
using EditableCV_backend.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EditableCV_backend.Test
{
  public class ContactInfoControllerTests
  {
    public ContactInfoControllerTests()
    {
      _repo = new MockContactInfoRepository();
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
      _controller = new ContactInfoController(_repo, _mapper)
      {
        ObjectValidator = mockValidator.Object,
      };
    }

    [Fact]
    public void GetContactInfo_ShouldReturnNotFound()
    {
      // Arrange & Act
      var response = _controller.GetContactInfo();
      // Assert
      Assert.IsType<NotFoundResult>(response.Result);
    }

    [Fact]
    public void PutAndGetInfo_ShouldReturnNoContentForPut_And_ShouldReturnDataForGet()
    {
      // Arrange
      ContactInfoUpdateDto updateDto = new ContactInfoUpdateDto()
      {
        Phone = "+2134534675",
        VK = "vk.com/testtest",
        Skype = "abc123",
        Instagram = "instagram.com/axaxaxaxa",
        LinkedIn = "somelink",
        YouTube = "youtube.com/channel",
        Facebook = "facebook.com/page",
      };
      // Act
      var putResult = _controller.PutContactInfo(updateDto);
      // Assert
      Assert.IsType<NoContentResult>(putResult);
      // Act
      var getResult = _controller.GetContactInfo();
      // Assert
      var okResult = Assert.IsType<OkObjectResult>(getResult.Result);
      ContactInfoReadDto info = Assert.IsType<ContactInfoReadDto>(okResult.Value);
      Assert.Equal(updateDto.Phone, info.Phone);
      Assert.Equal(updateDto.VK, info.VK);
      Assert.Equal(updateDto.Skype, info.Skype);
      Assert.Equal(updateDto.Instagram, info.Instagram);
      Assert.Equal(updateDto.LinkedIn, info.LinkedIn);
      Assert.Equal(updateDto.YouTube, info.YouTube);
      Assert.Equal(updateDto.Facebook, info.Facebook);
    }

    private readonly MockContactInfoRepository _repo;
    private readonly ResumeProfile _profile;
    private readonly MapperConfiguration _config;
    private readonly Mapper _mapper;
    private readonly ContactInfoController _controller;
  }
}
