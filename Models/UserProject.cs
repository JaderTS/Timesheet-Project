
namespace TrabalhoFinal
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserProject
    {
        public int UserProjectID { get; set; }
        public int ProjectActivityID { get; set; }
        public int UserID { get; set; }
        public double TotalHours { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual ProjectActivity ProjectActivity { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
