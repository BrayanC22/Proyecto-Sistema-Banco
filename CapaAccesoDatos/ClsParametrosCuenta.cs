using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
   public class ClsParametrosCuenta
    {
        //Cuenta 
        private Int16 id_Cuenta;
        private Int16 id_Cliente;
        private string cod_seguridad;
        private string numero_Cuenta;
        private Int16 id_Tipo_Cuenta;
        private double saldoInicial;

        public ClsParametrosCuenta(Int16 id_Cliente, string cod_seguridad, string numero_Cuenta, Int16 id_Tipo_Cuenta, double saldoInicial)
        {
            //this.id_Cuenta = id_Cuenta;
            this.id_Cliente = id_Cliente;
            this.cod_seguridad = cod_seguridad;
            this.numero_Cuenta = numero_Cuenta;
            this.id_Tipo_Cuenta = id_Tipo_Cuenta;
            this.saldoInicial = saldoInicial;
        }

        public Int16 Id_Cuenta
        {
            get { return id_Cuenta; }
            set { id_Cuenta = value; }
        }
        public Int16 Id_Cliente
        {
            get { return id_Cliente; }
            set { id_Cliente = value; }
        }

        public String Cod_seguridad
        {
            get { return cod_seguridad; }
            set { cod_seguridad = value; }
        }

        public String Numero_Cuenta
        {
            get { return numero_Cuenta; }
            set { numero_Cuenta = value; }
        }

        public Int16 Id_Tipo_Cuenta
        {
            get { return id_Tipo_Cuenta; }
            set { id_Tipo_Cuenta = value; }
        }

        public Double SaldoInicial
        {
            get { return saldoInicial; }
            set { saldoInicial = value; }
        }
    }
}
