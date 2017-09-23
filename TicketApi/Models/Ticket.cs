using System;
using System.ComponentModel.DataAnnotations;
using TicketApi.Attributes;

namespace TicketApi.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необхідно вказати номер квитка.")]
        [TicketNumber(ErrorMessage = "Номер повинен складатися з шести цифр.")]
        public string Number { get; set; }

        public Package Package { get; set; }
        public Color Color { get; set; }
        public Serial Serial { get; set; }

        [Required(ErrorMessage = "Необхідно вказати номер серії.")]
        [SerialNumber(ErrorMessage = "Номер серії повинен бути від 01 до 50.")]
        public string SerialNumber { get; set; }

        [StringLength(128, ErrorMessage = "Примітка не може бути більшою за 128 символів.")]
        public string Note { get; set; }

        [StringLength(32, ErrorMessage = "Дата не може бути довша за 32 символи.")]
        public string Date { get; set; }
        public DateTime AddDate { get; set; }

        public bool IsHappy { get; set; }
    }
}
