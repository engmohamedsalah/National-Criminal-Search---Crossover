using Foolproof;
using System.ComponentModel.DataAnnotations;

namespace NationalCriminal.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchCriminalProfileViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [MaxLength(200)]
        [Required]
        [StringLength(200,MinimumLength =3)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets from age.
        /// </summary>
        /// <value>
        /// From age.
        /// </value>
        [Display(Name ="From Age")]
        public int? fromAge { get; set; }

        /// <summary>
        /// Gets or sets to age.
        /// </summary>
        /// <value>
        /// To age.
        /// </value>
        [Display(Name = "To Age")]
        [GreaterThanOrEqualTo("fromAge")]
        public int? toAge { get; set; }

        /// <summary>
        /// Gets or sets from height.
        /// </summary>
        /// <value>
        /// From height.
        /// </value>
        [Display(Name = "from Height")]
        public int? fromHeight { get; set; }

        /// <summary>
        /// Gets or sets to height.
        /// </summary>
        /// <value>
        /// To height.
        /// </value>
        [Display(Name = "To Height")]
        [GreaterThanOrEqualTo("fromHeight")]
        public int? toHeight { get; set; }

        /// <summary>
        /// Gets or sets from weight.
        /// </summary>
        /// <value>
        /// From weight.
        /// </value>
        [Display(Name = "From Weight")]
        public int? fromWeight { get; set; }

        /// <summary>
        /// Gets or sets to weight.
        /// </summary>
        /// <value>
        /// To weight.
        /// </value>
        [GreaterThanOrEqualTo("fromWeight")]
        [Display(Name = "To Weight")]
        public int? toWeight { get; set; }
        /// <summary>
        /// Gets or sets the nationality identifier.
        /// </summary>
        /// <value>
        /// The nationality identifier.
        /// </value>
        [Display(Name = "Nationality")]
        public int? NationalityId { get; set; }

    }
}