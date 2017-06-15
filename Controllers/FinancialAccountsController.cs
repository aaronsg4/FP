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

namespace FP.Controllers
{
    public class FinancialAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FinancialAccounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(f => f.AccountType).Include(f => f.Household);
            return View(accounts.ToList());
        }

        // GET: FinancialAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialAccount financialAccount = db.Accounts.Find(id);
            if (financialAccount == null)
            {
                return HttpNotFound();
            }
            return View(financialAccount);
        }

        // GET: FinancialAccounts/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var householdId = user.HouseholdId;
            var householdIdb = db.Households.Where(h => h.Id == user.HouseholdId);
            var users = db.Users.Where(u => u.HouseholdId == householdId);
            var usersb = users.Where(u => u.Id == userId);

            ViewBag.AccountHolderUserId = new SelectList(usersb, "Id", "FullName");
            ViewBag.AccountTypeId = new SelectList(db.AccountTypes, "Id", "Name");
            ViewBag.HouseholdId = new SelectList(householdIdb, "Id", "Name");
            //ViewBag.Household = db.Households.Find(householdId).Name;
            //ViewBag.HouseholdId = householdId;
            return View();
        }

        // POST: FinancialAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,ActualBalance,AccountTypeId, AccountHolderUserId")] FinancialAccount financialAccount)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var householdId = db.Users.FirstOrDefault(u => u.Id == userId).HouseholdId;
                financialAccount.HouseholdId = householdId.Value;
                //financialAccount.HouseholdId = db.Households.Find(userId).Id;
                financialAccount.AccountHolderUserId = userId;
                financialAccount.ReconciledBalance = financialAccount.ActualBalance;
                financialAccount.AccountHolderUserId = userId;
                financialAccount.CreatedDate = DateTime.Now;

                //financialAccount.User.Id = financialAccount.AccountHolderUserId;
                db.Accounts.Add(financialAccount);
                db.SaveChanges();
                return RedirectToAction("Details","Households", new { id = userId });
            }

            ViewBag.AccountTypeId = new SelectList(db.AccountTypes, "Id", "Name", financialAccount.AccountTypeId);
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", financialAccount.HouseholdId);
            return View(financialAccount);
        }

        // GET: FinancialAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialAccount financialAccount = db.Accounts.Find(id);
            if (financialAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountTypeId = new SelectList(db.AccountTypes, "Id", "Name", financialAccount.AccountTypeId);
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", financialAccount.HouseholdId);
            return View(financialAccount);
        }

        // POST: FinancialAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ActualBalance,ReconciledBalance,CreatedDate,UpdatedDate,Include,HouseholdId,AccountTypeId")] FinancialAccount financialAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financialAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountTypeId = new SelectList(db.AccountTypes, "Id", "Name", financialAccount.AccountTypeId);
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", financialAccount.HouseholdId);
            return View(financialAccount);
        }

        // GET: FinancialAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialAccount financialAccount = db.Accounts.Find(id);
            if (financialAccount == null)
            {
                return HttpNotFound();
            }
            return View(financialAccount);
        }

        // POST: FinancialAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinancialAccount financialAccount = db.Accounts.Find(id);
            db.Accounts.Remove(financialAccount);
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
