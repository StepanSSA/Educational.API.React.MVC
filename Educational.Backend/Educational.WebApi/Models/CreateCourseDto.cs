using AutoMapper;
using Educational.Application.Common.Mappings;
using Educational.Application.Feature.CourseFeature.Commands.CreateCourse;

namespace Educational.WebApi.Models
{
    public class CreateCourseDto: IMapWith<CreateCourseCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public Guid TeacherId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCourseDto, CreateCourseCommand>()
                .ForMember(courseCom => courseCom.Name,
                    opt => opt.MapFrom(courseDto => courseDto.Name))
                .ForMember(courseCom => courseCom.Price,
                    opt => opt.MapFrom(courseDto => courseDto.Price))
                .ForMember(courseCom => courseCom.Description,
                    opt => opt.MapFrom(courseDto => courseDto.Description))
                .ForMember(courseCom => courseCom.Duration,
                    opt => opt.MapFrom(courseDto => courseDto.Duration))
                .ForMember(courseCom => courseCom.TeacherId,
                    opt => opt.MapFrom(courseDto => courseDto.TeacherId));
        }
    }
}
