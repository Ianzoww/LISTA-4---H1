using Microsoft.AspNetCore.Mvc;
using lista04Humberto.Models;


namespace lista04Humberto.Controllers
{

    [ApiController]
    [Route("API/Person")]
    public class PersonController : ControllerBase
    {
        static List<Person> PersonList = new List<Person>();
      

        // Action to create a person
        [HttpPost]
        [Route("CreatePerson")]
        public IActionResult CreatePerson(Person person)
        {
            PersonList.Add(person);
            return Ok();
        }


        // Action to update a person's data
        [HttpPut]
        [Route("UpdatePerson/{cpf}")]
        public IActionResult UpdatePerson(string cpf, Person personUpdated)
        {
            Person? personUpdate = PersonList.Where(a => a.CPF == cpf).FirstOrDefault();
            
            if(personUpdate is null)
            {
                return BadRequest("This person not exist!");
            }

            personUpdate.Name = personUpdated.Name;
            personUpdate.Height = personUpdated.Height;
            personUpdate.Weight = personUpdated.Weight;

            return Ok("Person updated successfully!");
        }



        // Action to remove a person
        [HttpDelete]
        [Route("RemovePerson")]
        public IActionResult RemovePerson(string cpf)
        {
            Person? personDelete = PersonList.Where(a => a.CPF == cpf).FirstOrDefault();

            if (personDelete is null)
            {
                return BadRequest("This person not exist!");
            }

            PersonList.Remove(personDelete);

            return Ok("Person removed successfully!");
        }

        // Action to search all
        [HttpGet]
        [Route("SearchAll")]
        public IActionResult SearchAll()
        {
            return Ok(PersonList);
        }


        // Action to search a person by CPF
        [HttpGet]
        [Route("SearchPersonByCPF/{cpf}")]
        public IActionResult SearchPersonByCPF(string cpf)
        {
            Person? personFound = PersonList.Where(a => a.CPF == cpf).FirstOrDefault();

            if (personFound is null)
            {
                return BadRequest("This person not exist!");
            }

            return Ok(personFound);
        }

        // Action to search people with good IMC
        [HttpGet]
        [Route("GetPeopleWithGoodIMC")]
        public IActionResult GetPeopleWithGoodIMC()
        {
            var goodIMCPeople = PersonList.Where(p =>
            {
                double imc = p.IMC();
                return imc >= 18.5 && imc <= 24.9;
            }).ToList();

            return Ok(goodIMCPeople);
        }

        // Action to search a person by CPF
        [HttpGet]
        [Route("SearchPersonByName/{name}")]
        public IActionResult SearchPersonByName(string name)
        {
            Person? personFound = PersonList.Where(a => a.Name == name).FirstOrDefault();

            if (personFound is null)
            {
                return BadRequest("This person not exist!");
            }

            return Ok(personFound);
        }
    }

  



}

