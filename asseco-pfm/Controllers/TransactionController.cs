﻿using asseco_pfm.Commands;
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
            _transactionService.ImportFile(file);

            return Ok("Imported");
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery] string transactionKind, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string sortBy, [FromQuery] SortOrderEnum sortOrder)
        {
            var transactionList = await _transactionService.GetTransactions();

            return Ok(transactionList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTransaction([FromRoute] int id)
        {
            var transactionList = await _transactionService.GetTransaction(id);

            return Ok(transactionList);
        }

        [HttpPost]
        [Route("{id}/categorize")]
        public async Task<IActionResult> TransactionsCategorize([FromRoute][Required] int id, [FromBody] TransactionCategorizeCommand transactionCategorizeCommand)
        {
            var result = await _transactionService.CategorizeTransaction(id, transactionCategorizeCommand);

            if (result == null)
            {
                return BadRequest("x-asee-problems: List [ \"provided - category - does - not - exists\" ]");
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("{id}/split")]
        public async Task<IActionResult> TransactionsSplit([FromRoute][Required] int id, [FromBody] TransactionSplitCommand splits)
        {
            var result = await _transactionService.TransactionsSplit(id, splits);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
