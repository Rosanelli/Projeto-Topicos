using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoTopicos.classes.EN
{
    public class MovimentoEN
    {
        public int _IDMovimento { get; set; }
        public int _TipoMovimento { get; set; }
        public decimal _Debito { get; set; }
        public decimal _Credito { get; set; }
        public decimal _Valor_Pago { get; set; }
        public decimal _Valor_Hora_Movimento { get; set; }
        public int _IDFrentista { get; set; }
    }
}