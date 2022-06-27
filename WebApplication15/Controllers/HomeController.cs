using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    public class HomeController : Controller
    {
        StudentMoc db = new StudentMoc();
        Student st=new Student();

        public IActionResult Index(string searchtext,int? no)
        {
            ViewBag.text = "";
            List<Student> students = db.GetAllStudents();
            if (searchtext != null)
            {
                students = students.FindAll(a => a.Name.Contains(searchtext));
                ViewBag.text = searchtext;
            }
            if(no != null)
            {
                students = students.Take(no.Value).ToList();
            }
            StudentIndexViewModel model = new StudentIndexViewModel()
            {
                students = students,
                texttosearch = searchtext ?? ""

            };
                return View(model);

        }
        
        public IActionResult details(int ?id)
        {
            if(id == null)
                return BadRequest();
          Student std=  db.GetStudentById(id.Value);
            if (std == null)
                return NotFound();
            return View(std);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Add(int id,string name,int age)
        {
            Student st = new Student() { Id = id, Name = name, Age = age };
            db.AddStudent(st);
            return RedirectToAction("index");
        }

        public ActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            Student std = db.GetStudentById(id.Value);
            if (std is null)
                return NotFound();
            return View(std);

        }
        [HttpPost]
        public ActionResult Edit(Student std)
        {
            db.UpdateStudent(std);
            return RedirectToAction("index");
        }
        public IActionResult delete(int? id)
        {
            if (id == null)
                return BadRequest();
            Student std = db.GetStudentById(id.Value);
            if (std == null)
                return NotFound();
            //db.DeleteStudent(id.Value);
            //return RedirectToAction ("index");
            return View(std);
        }
        [HttpPost]
        public IActionResult delete(int id)
        {
            db.DeleteStudent(id);
            return RedirectToAction("index");
        }
        
        public IActionResult Upload()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Upload(string name,IFormFile studentimge)
        {

            var arr=  studentimge.FileName.Split(".");
            string ext = arr[arr.Length-1];
            string path = ".//wwwroot//imags//"+name+"."+ext;
            using (var stream = new FileStream(path, FileMode.Create))
            {
                studentimge.CopyTo(stream);
            }
            return Content("image adding");
            
        }


    }
}

