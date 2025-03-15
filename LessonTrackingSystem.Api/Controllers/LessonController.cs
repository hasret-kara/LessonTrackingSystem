using LessonTrackingSystem.DataAccess.Entities;
using LessonTrackingSystemDataAccessLayer.BaseRepositori;
using Microsoft.AspNetCore.Mvc;

namespace LessonTrackingSystem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IRepository<Lesson> _repository;

        public LessonController(IRepository<Lesson> repository)
        {

            _repository = repository;
        }


        public async Task Index()
        {
            var entity = new Lesson()
            {
                Akts = 8,
                Code = "PRG001",
                Name = "Programlama"
            };

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }
    }
}