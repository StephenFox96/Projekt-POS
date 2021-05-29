using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Data
{
    //Model of database structure to be displayed on site
    public class PosModel
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Co2 { get; set; }
    }
}
