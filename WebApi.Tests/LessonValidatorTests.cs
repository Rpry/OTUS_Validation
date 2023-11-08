using FluentAssertions;
using WebApi.Models;
using WebApi.Validators;
using Xunit;

namespace WebApi.Tests
{
    public class LessonValidatorTests
    {
        private LessonValidator _validator;
        public LessonValidatorTests()
        {
            _validator = new LessonValidator();
        }
        
        [Fact]
        public void Validate_Should_Return_Success_For_Correct_Data()
        {
            //Arrange
            var model = new LessonModel
            {
                Subject = "subject",
                CourseId = 1
            };
            
            //Act
            var result = _validator.Validate(model);
            
            //Assert
            result.IsValid.Should().BeTrue();
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Validate_Should_Return_Error_If_Subject_Is_Null_Or_Empty(string subject)
        {
            //Arrange
            var model = new LessonModel
            {
                Subject = subject,
                CourseId = 1
            };
            
            //Act
            var result = _validator.Validate(model);
            
            //Assert
            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Validate_Should_Return_Error_If_CourseId_Is_Zero()
        {
            //Arrange
            var model = new LessonModel
            {
                Subject = "subject"
            };
            
            //Act
            var result = _validator.Validate(model);
            
            //Assert
            result.IsValid.Should().BeFalse();
        }
    }
}