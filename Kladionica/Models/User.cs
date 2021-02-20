using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kladionica.Models
{

    public class Game

    {
        [StringLength(50, MinimumLength = 3)]
        public string Sport { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string Participent { get; set; }
        public virtual OutcomeGame OutcomeGame { get; set; }
        public int Result { get; set; }
        [StringLength(5)]
        public string TimeOfGame { get; set; }
    }



    public class OutcomeGame
    {
        [StringLength(50, MinimumLength = 3)]
        public string Match { get; set; }
        public string ExpectedResult { get; set; }
        public int Coefficients { get; set; }
        public int SpecialOffer { get; set; }
        public string WinningOutcome { get; set; }
        public virtual Game Game { get; set; }
        public virtual SelectedOutcome SelectedOutcome { get; set; }

    }

    public class SelectedOutcome
    {
        public string Outcome { get; set; }
        public virtual Ticket Ticket { get; set; }
    }

    public class Ticket
    {
        [Key]
        public string SelectedOutcome { get; set; }
        public int Payment { get; set; }
        public int Costs { get; set; }
        public int Stake { get; set; }
        public int TotalCoefficient { get; set; }
        public string WinningTicket { get; set; }
        public int Gain { get; set; }
    }
}
