using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ReactASPNetMVCDemo.Controllers
{
    [RoutePrefix("contact-us")]
    public class ContactUsController : Controller
    {
        private readonly IContactService<ContactUs> _contactService;
     
        public ContactUsController(IContactService<ContactUs> contactService)
        {
            _contactService = contactService;
           
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("post")]
        //TODO: move to web API for real applications
        public async Task<JsonResult> AddMessage(ContactFormViewModel form)
        {
            //TODO: add validation
            await _contactService.AddAsync(form.Name, form.Email, form.Message);
            //TODO: create model for result and convert to json
            //return Content("Success");

            var result = new JsonResultModel() {
                Success = true,
                Message = "Success! Your message has beent sent."
            };
            return Json(result);
        }

        [Route("listing")]
        public async Task<ActionResult> Listing()
        {
            var list = await _contactService.GetAllAsync();
            //should map domain model - view model outside controller
            //using AutoMapper or other mapping libraries
            //but for demo purposes, let's map models manually 
            var model = new List<ContactFormViewModel>();
            foreach(var contact in list)
            {
                var item = new ContactFormViewModel() {
                    Name = contact.Name,
                    Email = contact.Email,
                    Message = contact.Message
                };
                model.Add(item);
            }

            return View(model);
        }
    }
}   