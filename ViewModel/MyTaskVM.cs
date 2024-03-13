using DotnetTask.Model;
using System.ComponentModel.DataAnnotations;

namespace DotnetTask.ViewModel
{
    public enum Status
    {
        Pending,
        Completed
    }
    public class MyTaskVM
    {
        [Required]
        public string TitleVM { get; set; }

        [Required]
        public string DescriptionVM { get; set; }
        [Required]
        public Status GetStatusVM { get; set; }
    }
}
