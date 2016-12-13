using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class CuentabancoBC
    {
        public List<CuentaBanco> getcuentabancobybanco(string codigo_banco)

        {

            List<CuentaBanco> lcuenta = new CuentabancoDAC().getallCuentabanco(codigo_banco);
            return lcuenta;
        }


        public string add_cuenta_banco(Int16 id_cuenta_banco,
                                        string codigo_banco,
                                        string numero_cuenta)

        {

            string add = new CuentabancoDAC().add_Cuentabanco(id_cuenta_banco, codigo_banco, numero_cuenta);

            return add;
        }
        public CuentaBanco getcuentabancobycuenta(string codigo_banco, int id_cuenta_banco)
        {

            CuentaBanco lcuenta = new CuentabancoDAC().getCuentabancobycuenta(codigo_banco.ToString(), id_cuenta_banco);
            return lcuenta;
        }


    }
}
