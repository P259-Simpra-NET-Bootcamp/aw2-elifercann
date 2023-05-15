using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Validation;

namespace SimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public StaffController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public IActionResult GetAllStaffs()
        {
            try
            {
                var staffs = _manager.StaffService.GetAllStaffs(false);
                return Ok(staffs);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        [HttpGet("{id}")]
        public IActionResult GetOneStaff([FromRoute] int id)
        {
            try
            {
                var staff = _manager.StaffService.GetOneStaffById(id, false);
                if (staff == null)
                    return NotFound();
                return Ok(staff);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }


        }
        [HttpGet("countryofcity")]
        public IActionResult GetCities([FromQuery] string city, [FromQuery] string country)
        {

            try
            {
               
                var cities = _manager.StaffService.GetStaffCityCountry(city, country);
                if (cities == null && !cities.Any())
                {
                    return NotFound("There are no staff in the given city and country.");
                }
                return Ok(cities);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
      

        [HttpPost]
        public IActionResult CreateOneStaff([FromBody] Staff staff)
        {
            var validator = new StaffValidator();
            var result = validator.Validate(staff);
            try
            {
                if (staff == null)
                {


                    return BadRequest();

                }
                else if (!result.IsValid)
                {
                    var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
                    var errorMessageString = string.Join(Environment.NewLine, errorMessages);
                    return BadRequest(errorMessageString);
                }

                _manager.StaffService.CreateOneStaff(staff);

                return StatusCode(201, staff);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateOneStaff([FromRoute] int id, [FromBody] Staff staff)
        {
            var validator = new StaffValidator();
            var result = validator.Validate(staff);
            try
            {
                if (staff == null)
                    return BadRequest();
                else if (!result.IsValid)
                {
                    var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
                    var errorMessageString = string.Join(Environment.NewLine, errorMessages);
                    return BadRequest(errorMessageString);
                }
                _manager.StaffService.UpdateOneStaff(id, staff, true);

                return Ok(staff);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneStaff([FromRoute] int id)
        {
            try
            {

                _manager.StaffService.DeleteOneStaff(id, false);

                return NoContent();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
