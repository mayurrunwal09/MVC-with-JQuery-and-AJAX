using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RailwaySystem.Models
{
    public class Railway
    {
        [Key]
        public int TrainId { get; set; }

        public int TrainNo { get; set; }

        [Required(ErrorMessage ="This Field is required")]
        [DisplayName("Train Name")]
        public string TrainName { get; set; }
        public DateTime Schedule { get;set; }

        [Required(ErrorMessage ="This field is required")]
        [DisplayName("Train Source")]
        public string Source { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [DisplayName("Train Destination")]
        public string Destination { get;set; }
    }
}
