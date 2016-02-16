namespace TrabalhoFinal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserProfile")]
    public partial class UserProfile
    {

        public UserProfile()
        {
            
            this.ProjectActivities = new HashSet<ProjectActivity>();
            this.UserProjects = new HashSet<UserProject>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Display(Name="Usuário")]
        public string UserName { get; set; }
    
        public virtual ICollection<ProjectActivity> ProjectActivities { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
