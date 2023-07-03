using Educational.Application.Common.Exeptions;
using Educational.Application.Interfaces;
using Educational.Domein;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Educational.Application.Feature.PurchasedCoursesFeatures.Commands.CreatePurchasedCourses
{
    internal class CreatePurchasedCoursesCommandHandler : IRequestHandler<CreatePurchasedCoursesCommand, Guid>
    {

        private readonly IEducationalDbContext context;

        public CreatePurchasedCoursesCommandHandler(IEducationalDbContext context)
        {
            this.context=context;
        }

        public async Task<Guid> Handle(CreatePurchasedCoursesCommand request, CancellationToken cancellationToken)
        {
            var student = context.Students.Where(s => s.UserId == request.UserId).FirstOrDefault() 
                ?? throw new NotFoundExeption(nameof(Student), request.UserId);
            var course = context.Courses.Where(c => c.Id == request.CoursId).FirstOrDefault() 
                ?? throw new NotFoundExeption(nameof(Course), request.CoursId);

            var studentCourse = await context.PurchasedCourses.Where(c => c.Student.UserId == request.UserId).Select(c => c.Course).ToListAsync(cancellationToken);

            foreach (var item in studentCourse)
            {
                if(item.Id == request.CoursId)
                    throw new DuplicateNameException(nameof(Course));
            }

            var purchased = new PurchasedCourses
            {
                Id = Guid.NewGuid(),
                Course = course,
                date = request.date,
                purchasePrice = request.purchasePrice,
                Student = student,
            };


            await context.PurchasedCourses.AddAsync(purchased, cancellationToken);
            await context.SaveChengesAsync(cancellationToken);

            return purchased.Id;
        }
    }
}
