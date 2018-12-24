namespace ProjectTeamManager.Model.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.UserStories = new HashSet<UserStory>();
        }
        public System.Guid Id { get; set; }
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [NameDuplicate(ErrorMessage = "Project name is existed in database")]
        [Required(ErrorMessage = "Name is required.")]
        [DisplayName("Project Name")]
        public string Name { get; set; }
        [DisplayName("Start Date")]
        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime EndDate { get; set; }
        [StringLength(50, ErrorMessage = "Client Name cannot be longer than 50 characters.")]
        [DisplayName("Client Name")]
        [Required(ErrorMessage = "Client Name is required.")]
        public string ClientName { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime InsAt { get; set; }
        public string InsBy { get; set; }
        public System.DateTime UpdAt { get; set; }
        public string UpdBy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserStory> UserStories { get; set; }
        public class NameDuplicateAttribute : ValidationAttribute
        {

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    //create instance of object of type ApplicationDbContext to access database
                    DBGroup1Entities db = new DBGroup1Entities();
                    //check for the supplied email in database
                    var query = db.Projects
                        .Where(p => p.Name.ToLower().Equals(value.ToString().ToLower()) && !p.IsDeleted)
                        .Select(p => new { Name = p.Name}
                    );
                    //if query contains results
                    if (query != null && query.Count() > 0)
                    {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(errorMessage);
                    }
                    //if program reach this point, we know that all requirements were met,
                    //therefore returning Success
                    return ValidationResult.Success;
                }
                return base.IsValid(value, validationContext);
            }

        }
    }
}
