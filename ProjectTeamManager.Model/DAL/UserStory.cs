﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectTeamManager.Model.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class UserStory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserStory()
        {
            this.ProjectTasks = new HashSet<ProjectTask>();
        }
    
        public System.Guid Id { get; set; }
        [Required(ErrorMessage = "Story is required.")]
        public string Story { get; set; }
        [DisplayName("Project Name")]
        [Required(ErrorMessage = "Project Name is required.")]
        public System.Guid ProjectId { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime InsAt { get; set; }
        public string InsBy { get; set; }
        public System.DateTime UpdAt { get; set; }
        public string UpdBy { get; set; }
    
        public virtual Project Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
    }
}
