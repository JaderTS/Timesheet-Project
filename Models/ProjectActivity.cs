namespace TrabalhoFinal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class ProjectActivity
    {
        public ProjectActivity()
        {
            this.UserProjects = new HashSet<UserProject>();
        }
    
        public int ProjectActivityID { get; set; }
        [Display(Name="Nome")]
        public string Name { get; set; }
        public int OwnerUserID { get; set; }
        public int ProjectTypeID { get; set; }
    
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }

        [Display(Name = "Projeto ou atividade")]
        public virtual ProjectType ProjectType { get; set; }
    }
}
