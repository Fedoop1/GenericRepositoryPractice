using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sample.Model;
using Sample.Repository.Interfaces;
using Sample.Service.Interfaces;

namespace GenericRepositoryPractice.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonService personService;
        private readonly ICountryService countryService;

        public PersonsController(IPersonService personService, ICountryService countryService) =>
            (this.personService, this.countryService) = (personService, countryService);

        // GET: Persons
        public IActionResult Index()
        {
            var sampleContext = personService.GetAll();
            return View(sampleContext);
        }

        // GET: Persons/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = personService.GetById(id.Value);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(countryService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Phone,Address,State,CountryId,Id")] Person person)
        {
            if (ModelState.IsValid)
            {
                personService.Create(person);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(countryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // GET: Persons/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = personService.GetById(id.Value);

            if (person == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(countryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Name,Phone,Address,State,CountryId,Id")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    personService.Update(person);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(countryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // GET: Persons/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = personService.GetById(id.Value);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var person = personService.GetById(id);
            personService.Delete(person);
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(long id)
        {
            return personService.GetById(id) != null;
        }
    }
}
