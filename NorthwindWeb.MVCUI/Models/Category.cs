using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindWeb.MVCUI.Models
{
    /*
     *  "id": 7,
        "description": "Dried fruit and bean curd",
        "name": "Produce"
     * 
     */
    public class Category
    {
        public int id { get; set; }
        public string description { get; set; }
        public string Name { get; set; }
    }
}
