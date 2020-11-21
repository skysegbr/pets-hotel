using System.ComponentModel.DataAnnotations;

namespace PeatHotel.Models
{
    public class HistoricoPeat
    {
        [Key]
        public int histPeatId { get; set; }
        public int peatId { get; set; }
        public Peat peat { get; set; }
        public string histSaude { get; set; }
        public string histObs { get; set; }
    }
}