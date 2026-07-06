using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendAssessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ConnectionProvider.ApplicationConnection _context;

        private readonly ILogger _logger;

        public OrderController(ConnectionProvider.ApplicationConnection context, ILogger<OrderController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("BatchPostOrders")]

        public async Task<IActionResult> BatchPostOrders([FromBody] List<Orders> orders)
        {
            try
            {
                await _context.orders.AddRangeAsync(orders);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving orders.");
                return StatusCode(500, "An error occurred while processing your request.");
            }


        }
        [HttpGet("TotalNumberOfOrders")]
        public async Task<IActionResult> TotalNumberOfOrders(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var recentOrders = await _context.orders.Where(o => o.SalesDate >= startDate && o.SalesDate <= endDate).ToListAsync();
                return Ok(new {RecentOrders = recentOrders.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving orders.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("TotalNumberOfCustomers")]
        public async Task<IActionResult> TotalNumberOfCustomers(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var CustomerCount = await _context.orders.Where(o => o.SalesDate >= startDate && o.SalesDate <= endDate).ToListAsync();
                return Ok(new {TotalCustomers = CustomerCount.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving orders.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("AverageOrderValue")]
        public async Task<IActionResult> AverageOrderValue(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var DateRange = await _context.orders.Where(o => o.SalesDate >= startDate && o.SalesDate <= endDate).ToListAsync();
                var averageOrderValue = await _context.orders.AverageAsync(o => o.UnitPrice);
                return Ok(new {AverageOrderValue = averageOrderValue });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving orders.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}