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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentCreateUpdateInputModel input)
        {
            try
            {

                int a = 0; int b = 1;
                int c = a / b;


                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var entity = new Student
                {
                    Name = input.Name,
                    Surname = input.Surname,
                    BirthDate = input.BirthDate,
                    Number = input.Number,
                    Gender = input.Gender,
                    IsDeleted = false
                };

                await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());

                throw ex;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] StudentCreateUpdateInputModel input, Guid id)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return NotFound();

                entity.Name = input.Name;
                entity.Surname = input.Surname;
                entity.BirthDate = input.BirthDate;
                entity.Number = input.Number;
                entity.Gender = input.Gender;

                _repository.Update(entity);
                await _repository.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw ex;
            }
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] StudentSearchInput input)
        {
            var data = await _repository.GetAllAsync();
            var filteredData = data
                .Where(x => x.IsDeleted == false)
                .Where(x =>
                    (string.IsNullOrEmpty(input.Name) || x.Name.Contains(input.Name)) &&
                    (string.IsNullOrEmpty(input.Surname) || x.Surname.Contains(input.Surname)) &&
                    (!input.BirthDate.HasValue || x.BirthDate >= input.BirthDate.Value))
                   .ToList();

            return Ok(filteredData);

        }
    }
}
