using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FP.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace FP.Controllers
{
    public class HouseholdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Households
        public ActionResult Index()
        {
            return View(db.Households.ToList());
        }

        // GET: Households/Details/5
        //[AuthorizeHouseholdRequired]
        public ActionResult Details(int? id)
        {
            if (id == null)

            {

                var NotLoggedIn = "You must be logged in to view your household details.";
                TempData["message"] = NotLoggedIn;
             
                return RedirectToAction("Login", "Account");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            

            
            //ApplicationUser user = db.Users.Find(id);
            Household household = db.Households.Find(id);
            if (household != null)
            {
                var users = db.Users.Where(u=>u.HouseholdId == household.Id).ToList();
                //var users = db.Households.Find(user.HouseholdId).Users;

                household.Users = users;
            }
           
            //Household household = db.Households.Find(id);
          else
            {
                ////Then say if the user is not in a household tell them they must create or join a household

                var NotPartofHousehold = "You must be part of a household to view it's details.  If you have been invited to join a household, please join first by clicking 'Join Household', or create a new household.";
                TempData["message"] = NotPartofHousehold;
                return RedirectToAction("Index","Home");
            }
            return View(household);
        }
//Get
        public ActionResult MyHouseholdDetails()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            if (userId !=null)
            {
                var householdId = db.Users.FirstOrDefault(u => u.Id == userId).HouseholdId;
                if (householdId != null)
                {
                    Household household = db.Households.Find(householdId);
                    return PartialView("~/Views/Households/_MyHouseholdDetails.cshtml", household);
                }

                else return PartialView("~/Views/Households/_MyHouseholdDetails.cshtml");

            }
           else return PartialView("~/Views/Households/_MyHouseholdDetails.cshtml");
        }

        public ActionResult MyHouseholdDetailsb()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            if (userId != null)
            {
                if (user.HouseholdId !=null)
                {
                    var householdId = db.Users.FirstOrDefault(u => u.Id == userId).HouseholdId;
                    if (householdId != null)
                    {
                        Household household = db.Households.Find(householdId);
                        return PartialView("~/Views/Households/_MyHouseholdDetailsb.cshtml", household);
                    }
                }
                

                return PartialView("~/Views/Households/_MyHouseholdDetailsb.cshtml");

            }
            return PartialView("~/Views/Households/_MyHouseholdDetailsb.cshtml");
        }


        // GET: Households/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Households/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Household household)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.Find(userId);

                if (userId != null)
                {
                    household.CreatedDate = DateTime.Now;
                    household.UserId = userId;
                    db.Households.Add(household);
                    db.SaveChanges();
                    //Can add some kind of tempdata message here about what to do next
                    return RedirectToAction("Details","Household", new { id = household.Id });
                }
                else
                {
                    //you arent logged in, please log in to create a household
                    var NotLoggedIn = "You are not logged in.  Please log in to create a household.";
                    TempData["message"] = NotLoggedIn;
                    return RedirectToAction("Index", "Home");
                }
              

            }

            return View(household);
        }
        //Get: Households/Join/5


            public PartialViewResult JoinHouseholdPopUp()
        {
            return PartialView();
        }




        public async Task <ActionResult> JoinHousehold(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userinHousehold = db.Users.Find(User.Identity.GetUserId());
            await ControllerContext.HttpContext.RefreshAuthentication(userinHousehold);
            Household household = db.Households.Find(id);
            //Invitations invitation = db.Invitations.Find(household)
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
           
            
            //if (household.)

            if (household == null)
            {
                return HttpNotFound();
            }

            if (userId != null)
            {


                return View(household);

            }

            else
            {
                return RedirectToAction("Register", "Account");
            }
        }

        public ActionResult JoinHouseholdEmailConfirm([Bind(Include = "InvitedEmail")] Household household)
        {
            if (ModelState.IsValid)

            {
                var invitedhousehold = db.Households.FirstOrDefault(h => h.InvitedEmail == household.InvitedEmail);
                if (invitedhousehold != null)
                {
                    var householdId = invitedhousehold.Id;
                    Household householdtojoin = db.Households.Find(householdId);
                    return View(householdtojoin);
                }
                else
                {
                    var NotInvited = "Sorry we did not find your invitation in the system.  Please confirm that you have been invited to join a household with the email you are using.";
                    TempData["message"] = NotInvited;
                    return RedirectToAction("Index","Home");
                }
                
            }
            return View();
        }
        //POST

        public ActionResult JoinHouseholdConfirm([Bind(Include ="Id, Name,UserId,Description,CreatedDate")] Household household)
        {
            if (ModelState.IsValid)

            {
                var newhousehold = db.Households.AsNoTracking().FirstOrDefault(h => h.Id == household.Id);
                    var userId = User.Identity.GetUserId();
                    var user = db.Users.Find(userId);
                    household.Users = newhousehold.Users;
                user.HouseholdId = household.Id;
                
                    household.Users.Add(user);
                
                db.SaveChanges();
                    return RedirectToAction("Details", "Households",new { id = household.UserId });
                }

            return RedirectToAction("Index");
        }

        // public void AddUserToAProject(string userId, int projectId)
        //         {
        //ApplicationUser user = db.Users.Find(userId);
        //Project project = db.Projects.Find(projectId);
        // project.Users.Add(user);
        // db.SaveChanges();


        //Leave Household GET
        public ActionResult LeaveHousehold(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(Id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }


        //Leave Household POST


        public ActionResult LeaveHouseholdConfirm(int Id)
        {

            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);

            Household household = db.Households.Find(Id);
            household.Users.Remove(user);


            db.SaveChanges();
            return RedirectToAction("Index","Home");


        }



        // GET: Households/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreatedDate,DissolvedDate")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Entry(household).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(household);
        }

        // GET: Households/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Household household = db.Households.Find(id);
            db.Households.Remove(household);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
