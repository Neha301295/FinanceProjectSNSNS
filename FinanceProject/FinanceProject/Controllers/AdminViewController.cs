using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using FinanceProject.Models;

namespace FinanceProject.Controllers
{
    [EnableCors(origins:"http://localhost:4200", headers:"*", methods:"*")]
    public class AdminViewController : ApiController
    {
        private dbfinanceEntities db = new dbfinanceEntities();

        // GET: api/AdminView
        public IQueryable<RegisterBank> GetRegisterBanks()
        {
            return db.RegisterBanks;
        }

        // GET: api/AdminView/5
        [ResponseType(typeof(RegisterBank))]
        public IHttpActionResult GetRegisterBank(string id)
        {
            RegisterBank registerBank = db.RegisterBanks.Find(id);
            if (registerBank == null)
            {
                return NotFound();
            }

            return Ok(registerBank);
        }

        // PUT: api/AdminView/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegisterBank(string id, RegisterBank registerBank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registerBank.username)
            {
                return BadRequest();
            }

            db.Entry(registerBank).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterBankExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AdminView
        [ResponseType(typeof(RegisterBank))]
        public IHttpActionResult PostRegisterBank(RegisterBank registerBank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegisterBanks.Add(registerBank);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RegisterBankExists(registerBank.username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = registerBank.username }, registerBank);
        }

        // DELETE: api/AdminView/5
        [ResponseType(typeof(RegisterBank))]
        public IHttpActionResult DeleteRegisterBank(string id)
        {
            RegisterBank registerBank = db.RegisterBanks.Find(id);
            if (registerBank == null)
            {
                return NotFound();
            }

            db.RegisterBanks.Remove(registerBank);
            db.SaveChanges();

            return Ok(registerBank);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegisterBankExists(string id)
        {
            return db.RegisterBanks.Count(e => e.username == id) > 0;
        }
    }
}