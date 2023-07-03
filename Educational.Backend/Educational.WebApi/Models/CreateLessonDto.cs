using AutoMapper;
using Educational.Application.Common.Mappings;
using Educational.Application.Feature.LessonFeatures.Commands.CreateLesson;
using Microsoft.AspNetCore.Mvc;

namespace Educational.WebApi.Models
{
    public class CreateLessonDto : IMapWith<CreateLessonCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [FromForm]
        public IFormFile Video { get; set; }
        public Guid CourseId { get; set; }
        public int Number { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateLessonDto, CreateLessonCommand>();
        }
    }
}
