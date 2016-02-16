
namespace TrabalhoFinal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class ProjectType
    {
        public ProjectType()
        {
            this.ProjectActivity = new HashSet<ProjectActivity>();
        }
    
        public int ProjectTypeID { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }
    
        public virtual ICollection<ProjectActivity> ProjectActivity { get; set; }
    }
}
