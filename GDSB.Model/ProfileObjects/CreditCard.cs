using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDSB.Model.ProfileObjects
{
    public class CreditCard
    {
        public string cardNumer = string.Empty;
        public string nomeDescrito = string.Empty;
        public string mesAnoVencimento = string.Empty;
        public string codigo = string.Empty;
        public string banco = string.Empty;
        public string bandeira = string.Empty;

        public DateTime dtCreated;
    }
}
