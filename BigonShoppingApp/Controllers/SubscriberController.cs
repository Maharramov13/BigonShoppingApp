using BigonShoppingApp.Models;
using BigonShoppingApp.Models.Entities;
using BigonShoppingApp.Servicers.email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace BigonShoppingApp.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly IEmailService _service;
        private readonly AppDbContext _context;

        public SubscriberController(IEmailService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }
        public async Task<IActionResult> CreateSub(string email)
        {
            if (!IsValidEmail(email))
                return BadRequest();

            Subscriber subscriber = new Subscriber()
            {
                EmailAdress = email,
                CreatedAt = DateTime.Now
            };



            string title = "Hi";

            string token = $"#demo-{subscriber.EmailAdress}-{subscriber.CreatedAt:yyyy-MM-dd HH:mm:ss.fff}-bigon";
            token = HttpUtility.UrlEncode(token);
            string url = $"{Request.Scheme}://{Request.Host}/subscribe-approve?token={token}";
            string body = $"<p>Hi,</p><p>To Sub <a href=\"{url}\">Click!</a></p>";

            var flag = await _service.SendAsync(email, title, body);

            if (!flag)
                return BadRequest(new { asdas = "Request getmedi" });

            await _context.Subsciribers.AddAsync(subscriber);
            await _context.SaveChangesAsync();


            return Ok(new { correct = "Elave olundu:)" });
        }

        public async Task<IActionResult> ApproveSub(string email)
        {
            if (!IsValidEmail(email))
                return BadRequest();

            Subscriber subscriber = new Subscriber()
            {
                EmailAdress = email,
                CreatedAt = DateTime.Now
            };



            string title = "Hi";

            string token = $"#demo-{subscriber.EmailAdress}-{subscriber.CreatedAt:yyyy-MM-dd HH:mm:ss.fff}-bigon";
            token = HttpUtility.UrlEncode(token);
            string url = $"{Request.Scheme}://{Request.Host}/subscribe-approve?token={token}";
            string body = $"<p>Hi,</p><p>To Sub <a href=\"{url}\">Click!</a></p>";

            var flag = await _service.SendAsync(email, title, body);

            if (!flag)
                return BadRequest(new { asdas = "Request getmedi" });

            await _context.Subsciribers.AddAsync(subscriber);
            await _context.SaveChangesAsync();


            return Ok(new { correct = "Elave olundu:)" });
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }


    class Response
    {
        public string Message { get; set; }
        public string Type { get; set; }
    }
}
