
namespace B2WTI.PCFTI.APLICACAO.SERVICO.Controllers
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using System.Web.Http.OData;
    using System.Web.Http.OData.Routing;

    public class FornecedorController : ODataController
    {
        private PCFTIDataContext db = new PCFTIDataContext();

        // GET: odata/MinhaEntidade
        [EnableQuery]
        public IQueryable<Fornecedor> GetFornecedor()
        {
            return db.Fornecedor;
        }

        // GET: odata/MinhaEntidade(5)
        [EnableQuery]
        public SingleResult<Fornecedor> GetMinhaEntidade([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.Fornecedor.Where(fornecedor => fornecedor.FornecedorId == key));
        }

        // PUT: odata/MinhaEntidade(5)
        public async Task<IHttpActionResult> Put([FromODataUri] Guid key, Delta<Fornecedor> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Fornecedor fornecedor = await db.Fornecedor.FindAsync(key);
            if (fornecedor == null)
            {
                return NotFound();
            }

            patch.Put(fornecedor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(fornecedor);
        }

        // POST: odata/MinhaEntidade
        public async Task<IHttpActionResult> Post(Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fornecedor.Add(fornecedor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FornecedorExists(fornecedor.FornecedorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(fornecedor);
        }

        // PATCH: odata/MinhaEntidade(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<Fornecedor> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Fornecedor fornecedor = await db.Fornecedor.FindAsync(key);
            if (fornecedor == null)
            {
                return NotFound();
            }

            patch.Patch(fornecedor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(fornecedor);
        }

        // DELETE: odata/MinhaEntidade(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] Guid key)
        {
            Fornecedor fornecedor = await db.Fornecedor.FindAsync(key);
            if (fornecedor == null)
            {
                return NotFound();
            }

            db.Fornecedor.Remove(fornecedor);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FornecedorExists(Guid key)
        {
            return db.Fornecedor.Count(e => e.FornecedorId == key) > 0;
        }

    }
}