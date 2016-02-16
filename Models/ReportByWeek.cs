using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFinal.Models
{
    public class ReportByWeek
    {
        public virtual string UserName { get; set; }

        public virtual string ProjectName { get; set; }

        public virtual int? DateNumber { get; set; }

        public virtual double TotalHour { get; set; }
    }
}