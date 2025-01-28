using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday_Project.Data.Models
{
    public class Tourist
    {
        public Tourist()
        {

        }
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
    }
}
