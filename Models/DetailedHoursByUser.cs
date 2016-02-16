using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFinal.Models
{
    public class DetailedHoursByUser
    {
        public virtual string UserName { get; set; }

        public virtual string ProjectName { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual double TotalHours { get; set; }
    }
}