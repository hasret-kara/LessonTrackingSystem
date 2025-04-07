using LessonTrackingSystem.DataAccess.Entities;
using LessonTrackingSystem.DataAccess.Models;
using LessonTrackingSystemDataAccessLayer.BaseRepositori;
using Microsoft.AspNetCore.Mvc;

namespace StudentTrackingSystem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepository<Student> _repository;

        public StudentController(IRepository<Student> repository)
        {

            _repository = repository;
        }


        [HttpGet]
        public async Task<Student> Get(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity;
        }


        [HttpPost]
        public async Task Create([FromBody] StudentCreateUpdateInputModel input)
        {
            var entity = new Student
            {
                Name = input.Name,
                Surname = input.Surname,
                BirthDate = input.BirthDate,
                Number = input.Number,
                Gender = input.Gender
            };
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }


        [HttpPut]
        public async Task Update([FromBody] StudentCreateUpdateInputModel input, Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                entity.Name = input.Name;
                entity.Surname = input.Surname;
                entity.BirthDate = input.BirthDate;
                entity.Number = input.Number;
                entity.Gender = input.Gender;

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
        public async Task<List<Student>> Search([FromBody] StudentSearchInput input)
        {
            var data = await _repository.GetAllAsync();
            var filteredData = data.Where(x => x.Name == input.Name || x.Surname == input.Surname || x.BirthDate >= input.BirthDate);

            return filteredData.ToList();
        }
    }
}












































