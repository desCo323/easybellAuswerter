using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasybellAuswerter
{
     public class Call
    {
        public DateTime timestamp { get; set; }   
        public int duration { get; set; }   
        public String ownNumber { get; set; }  
        public String richtung { get; set; }
        public String gegenstelle{ get; set; }    

        public override string ToString()
        {
            return timestamp + " " + duration + " " + ownNumber + " " + richtung + " " + gegenstelle;
        }
    }
}
