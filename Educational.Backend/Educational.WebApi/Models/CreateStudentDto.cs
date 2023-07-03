using AutoMapper;
using Educational.Application.Common.Mappings;
using Educational.Application.Feature.StudentFeatures.Commands.CreateStudent;

namespace Educational.WebApi.Models
{
    public class CreateStudentDto : IMapWith<CreateStudentCommand>
    {
        public Guid UserId { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<CreateStudentDto,CreateStudentCommand>();
        }
    }
}
