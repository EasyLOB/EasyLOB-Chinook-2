using Chinook.Data.Resources;
using System.ComponentModel.DataAnnotations;

namespace Chinook.Mvc
{
    public partial class CustomerDocumentViewModel
    {
        #region Properties

        [Display(Name = "PropertyFileName", ResourceType = typeof(CustomerDocumentResources))]
        //[Required] // !!! EDM
        [StringLength(100)]
        public virtual string FileName { get; set; }

        [Display(Name = "PropertyFileAcronym", ResourceType = typeof(CustomerDocumentResources))]
        //[Required] // !!! EDM
        [StringLength(10)]
        public virtual string FileAcronym { get; set; }

        #endregion Properties
    }
}