using System.ComponentModel.DataAnnotations;

namespace Api.Verbs.Dictionary.Models
{
    public class Verbs
    {
        [Key]
        public string present { get ; set; }
        public string past { get; set; }
        public string pastParticiple { get; set; }
        public string spanish { get; set; }
        public string pronuciation {  get; set; }
    }
}
