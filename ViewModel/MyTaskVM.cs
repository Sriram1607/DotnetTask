using DotnetTask.Model;
using System.ComponentModel.DataAnnotations;

namespace DotnetTask.ViewModel
{
    public class MyTaskVM
    {
        [Required]
        public int TaskId { set; get; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
