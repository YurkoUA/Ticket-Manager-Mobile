using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApi.Models
{
    public class Package
    {
        // TODO: Add validation attributes.

        public int Id { get; set; }
        public string Name { get; set; }
        public int TicketsCount { get; set; }

        public Color Color { get; set; }
        public Serial Serial { get; set; }

        public int? FirstNumber { get; set; }
        public double Nominal { get; set; }

        public bool IsSpecial { get; set; }
        public bool IsOpened { get; set; }

        public string SpecialString => IsSpecial ? "Спеціальна" : "Звичайна";
        public string OpenedString => IsOpened ? "Відкрита" : "Закрита";
        public string StatusString => $"{OpenedString} / {SpecialString}";

        public string Note { get; set; }
        public DateTime Date { get; set; }
    }
}
