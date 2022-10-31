using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMI.Gateways.Data.Entities
{
    public class PeripheralDevice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int GatewayId { get; set; }

        public int UID { get; set; }

        [DataType(DataType.Text)]
        public string Vendor { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public bool IsOnline { get; set; }
    }
}