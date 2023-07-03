using AutoMapper;
using Educational.Application.Common.Mappings;
using Educational.Application.Feature.LessonFeatures.Commands.UpdateLesson;

namespace Educational.WebApi.Models
{
    public class UpdateLessonDto : IMapWith<UpdateLessonCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateLessonDto, UpdateLessonCommand>();
        }
    }
}
