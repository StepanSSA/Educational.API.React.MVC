using AutoMapper;
using Educational.Application.Common.Mappings;
using Educational.Application.Feature.PurchasedCoursesFeatures.Commands.CreatePurchasedCourses;

namespace Educational.WebApi.Models
{
    public class CreatePurchasedCoursesDto : IMapWith<CreatePurchasedCoursesCommand>
    {
        public Guid CoursId { get; set; }
        public DateTime date { get; set; }
        public double purchasePrice { get; set; }
        public Guid UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePurchasedCoursesDto, CreatePurchasedCoursesCommand>();
        }
    }
}
