using asseco_pfm.Models;
using asseco_pfm.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace asseco_pfm.Controllers
{
    [ApiController]
    [Route("transaction")]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("import")]
        public IActionResult ImportFile(IFormFile file)
        {
            if (file == null) return BadRequest("Missing File");

            _transactionService.ImportFile(file);

            return Ok("Imported");
        }

        [HttpPost]
        public  IActionResult AddTransaction([FromBody] Transaction transaction)
        {
            var result =  _transactionService.AddTransaction(transaction);
            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transactionList = await _transactionService.GetTransactions();

            if (transactionList == null) 
                return BadRequest("No Transactions Found");

            return Ok(transactionList);
        }

        [HttpPost]
        [Route("{id}/categorize")]
        public  IActionResult TransactionsCategorize([FromRoute][Required] int id, [FromBody] String catCode)
        {
            var result = _transactionService.CategorizeTransaction(id, catCode);

            if(result == null)
            {
                return BadRequest("Couldn't Categorize");
            }

            return Ok(result);
        }
    }
}
