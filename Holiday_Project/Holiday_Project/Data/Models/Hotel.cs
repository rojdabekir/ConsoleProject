using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday_Project.Data.Models
{
    public class Hotel
    {
        public Hotel()
        {

        }

        public Hotel(string name)
        {
            this.Name = name;
        }
        public int Id { get; set; }

        
        public string Name { get; set; }
    }
}
