using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using nutriTrackWeb.Models;

namespace nutriTrackWeb.Controllers
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _config;

        public ContactController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send(Contact contact)
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string sql = @"INSERT INTO contact 
                           (name, email, whatsapp, message, createDate)
                           VALUES (@name, @mail, @whats, @msg, GetDate())";

            using var cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@name", contact.Name);
            cmd.Parameters.AddWithValue("@mail", contact.Email);
            cmd.Parameters.AddWithValue("@whats", contact.Whatsapp);
            cmd.Parameters.AddWithValue("@msg", contact.Message);

            cmd.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }
    }
}
