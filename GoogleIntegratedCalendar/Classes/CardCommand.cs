using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZKO.Classes
{
    public class CardCommand
    {
        public Enums.CardCommandEnum Command { get; set; }
        public UserControls.Formulars.FormFieldCard Card { get; set; }

        public CardCommand(UserControls.Formulars.FormFieldCard card, Enums.CardCommandEnum command)
        {
            Card = card;
            Command = command;
        }
    }
}
