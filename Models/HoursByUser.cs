using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFinal.Models
{
    public class HoursByUser
    {
        public virtual string UserName { get; set; }

        public virtual double TotalHour { get; set; }
    }
}