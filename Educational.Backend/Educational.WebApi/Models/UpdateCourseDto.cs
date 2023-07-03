using AutoMapper;
using Educational.Application.Common.Mappings;
using Educational.Application.Feature.CourseFeature.Commands.UpdateCourse;

namespace Educational.WebApi.Models
{
    public class UpdateCourseDto : IMapWith<UpdateCourseCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public bool Confirmed { get; set; }
        public virtual Guid TeacherId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCourseDto, UpdateCourseCommand>()
                .ForMember(courseCom => courseCom.Name,
                    opt => opt.MapFrom(courseDto => courseDto.Name))
                .ForMember(courseCom => courseCom.Price,
                    opt => opt.MapFrom(courseDto => courseDto.Price))
                .ForMember(courseCom => courseCom.Description,
                    opt => opt.MapFrom(courseDto => courseDto.Description))
                .ForMember(courseCom => courseCom.Duration,
                    opt => opt.MapFrom(courseDto => courseDto.Duration))
                .ForMember(courseCom => courseCom.TeacherId,
                    opt => opt.MapFrom(courseDto => courseDto.TeacherId))
                .ForMember(courseCom => courseCom.Confirmed,
                    opt => opt.MapFrom(courseDto => courseDto.Confirmed));
        }
    }
}
