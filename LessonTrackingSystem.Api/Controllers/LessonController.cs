using LessonTrackingSystem.DataAccess.Entities;
using LessonTrackingSystem.DataAccess.Models;
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


        [HttpGet]
        public async Task<Lesson> Get(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity;
        }


        [HttpPost]
        public async Task Create([FromBody] LessonCreateUpdateInputModel input)
        {
            var entity = new Lesson
            {
                Name = input.Name,
                Code = input.Code,
                Akts = input.Akts
            };
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }


        [HttpPut]
        public async Task Update([FromBody] LessonCreateUpdateInputModel input, Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                entity.Name = input.Name;
                entity.Code = input.Code;
                entity.Akts = input.Akts;

                _repository.Update(entity);
                await _repository.SaveChangesAsync();
            }

        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }


        [HttpPost]
        [Route("Search")]
        public async Task<List<Lesson>> Search([FromBody] LessonSearchInput input)
        {
            var data = await _repository.GetAllAsync();
            var filteredData = data.Where(x => x.Name == input.Name || x.Code == input.Code || x.Akts == input.Akts);

            return filteredData.ToList();

        }
    }
}