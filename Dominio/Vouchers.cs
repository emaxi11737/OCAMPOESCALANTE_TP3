using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vouchers
    {
        public int Id { get; set;}
        public string CodigoVoucher { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro;
        public Clientes cliente;
        public Productos producto;
    }
}
