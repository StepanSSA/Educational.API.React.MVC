using AutoMapper;
using Educational.Application.Common.Mappings;
using Educational.Application.Feature.HomeworkFeatures.Commands.CreateHomework;

namespace Educational.WebApi.Models
{
    public class CreateHomeworkDto : IMapWith<CreateHomeworkCommand>
    {
        public Stream File { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime date { get; set; }
        public int Score { get; set; }

        public Guid StudentId { get; set; }

        public Guid LessonId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateHomeworkDto, CreateHomeworkCommand>();
        }
    }
}
