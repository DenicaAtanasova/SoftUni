namespace ProjectRider.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    [ValidateInput(false)]
    public class ProjectController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new ProjectRiderDbContext())
            {
                List<Project> projects = db.Projects.ToList();

                return View(projects);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            using (var db = new ProjectRiderDbContext())
            {
                db.Projects.Add(project);
                db.SaveChanges();

                return this.Redirect("/");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            using (var db = new ProjectRiderDbContext())
            {
                Project projectFromDb = db.Projects.Find(id);

                return View(projectFromDb);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Project project)
        {
            using (var db = new ProjectRiderDbContext())
            {
                Project projectFromDb = db.Projects.Find(id);

                projectFromDb.Title = project.Title;
                projectFromDb.Description = project.Description;
                projectFromDb.Budget = project.Budget;

                db.SaveChanges();

                return Redirect("/");
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            using (var db = new ProjectRiderDbContext())
            {
                Project projectFromDb = db.Projects.Find(id);

                return View(projectFromDb);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Project reportModel)
        {
            using (var db = new ProjectRiderDbContext())
            {
                Project projectFromDb = db.Projects.Find(id);

                db.Projects.Remove(projectFromDb);
                db.SaveChanges();

                return Redirect("/");
            }
        }
    }
}