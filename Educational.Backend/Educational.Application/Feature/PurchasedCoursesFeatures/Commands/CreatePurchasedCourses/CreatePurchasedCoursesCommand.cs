using MediatR;

namespace Educational.Application.Feature.PurchasedCoursesFeatures.Commands.CreatePurchasedCourses
{
    public class CreatePurchasedCoursesCommand : IRequest<Guid>
    {
        public Guid CoursId { get; set; }
        public DateTime date { get; set; }
        public double purchasePrice { get; set; }
        public Guid UserId { get; set; }
    }
}
