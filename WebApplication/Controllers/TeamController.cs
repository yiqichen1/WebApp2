using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        //get from db to post to site
        [HttpGet("[action]")]
        public IEnumerable<TeamMember> GetAllTeamMembers()
        {
            var teamMembers = new List<TeamMember>();
            using (SqlConnection connection = new SqlConnection("Data Source =.; Initial Catalog = ProjectDB; Integrated Security = True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select * From Team", connection);
                var reader = command.ExecuteReader();
                var output = string.Empty;
                while (reader.Read())
                {
                    var teamMember = new TeamMember();
                    teamMember.FirstName = reader.GetValue(0).ToString();
                    teamMember.Email = reader.GetValue(1).ToString();
                    teamMembers.Add(teamMember);
                }
                connection.Close();
            }
            return teamMembers;
        }

        [HttpPost("[action]")]
        //http post to update DB with new member
        public IActionResult AddTeamMember([FromBody]string stringCommand)
        {
            using (SqlConnection connection = new SqlConnection("Data Source =.; Initial Catalog = ProjectDB; Integrated Security = True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(stringCommand, connection);
                //execute sql command
                command.ExecuteNonQuery();
                connection.Close();
            }
            return null;
        }

        [HttpPut("[action]")]
        //delete a member from db 
        public void RemoveTeamMember(string stringCommand)
        {
            using (SqlConnection connection = new SqlConnection("Data Source =.; Initial Catalog = ProjectDB; Integrated Security = True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(stringCommand, connection);
                //execute the sql command
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
            


        public class TeamMember
        {
            public string FirstName { get; set; }
            public string Email { get; set; }
            
        }
    }
}
