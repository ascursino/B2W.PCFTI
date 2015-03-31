
namespace B2WTI.PCFTI.APLICACAO.SERVICO.Controllers
{
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.HORIZONTAL;
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
    using System.Web.Http.OData.Query;
    using System.Web.Http.OData.Routing;

    [Authorize()]
    public class FornecedorController : ODataController
    {
        private PCFTIDataContext db = new PCFTIDataContext();

        [HttpGet]
        // GET: odata/Fornecedor
        [Queryable(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<Fornecedor> GetFornecedor()
        {
            return db.Fornecedor;
        }

        // GET: odata/Fornecedor(5)
        [EnableQuery]
        public SingleResult<Fornecedor> GetFornecedor([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.Fornecedor.Where(fornecedor => fornecedor.FornecedorId == key));
        }

        // PUT: odata/Fornecedor(5)
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

        // POST: odata/Fornecedor
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

        // PATCH: odata/Fornecedor(5)
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

        // DELETE: odata/Fornecedor(5)
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