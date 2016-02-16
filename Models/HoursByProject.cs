using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFinal.Models
{
    public class HoursByProject
    {
        public virtual string ProjectName { get; set; }

        public virtual string ProjectType { get; set; }

        public virtual string ProjectOwner { get; set; }

        public virtual double TotalHour { get; set; }
    }
}