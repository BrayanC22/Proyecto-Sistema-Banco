using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
   public class ClsParametrosTarjeta
    {
        //Tarjeta
        private Int16 id_Tarjeta;
        private Int16 id_Cuenta;
        private String codigoSeguridad;
        private Int16 id_Tipo_Tarjeta;
        private Int16 id_Institucion_Bancaria;
        private String fechaEx;
        private String numeroTarjeta;

        public ClsParametrosTarjeta(String numeroTarjeta, String fechaEx, Int16 id_Cuenta, String codigoSeguridad, Int16 id_Tipo_Tarjeta, Int16 id_Institucion_Bancaria)
        {
            // this.id_Tarjeta = id_Tarjeta;
            this.id_Cuenta = id_Cuenta;
            this.codigoSeguridad = codigoSeguridad;
            this.id_Tipo_Tarjeta = id_Tipo_Tarjeta;
            this.id_Institucion_Bancaria = id_Institucion_Bancaria;
            this.fechaEx = fechaEx;
            this.numeroTarjeta = numeroTarjeta;
        }

        public Int16 Id_Tarjeta
        {
            get { return id_Tarjeta; }
            set { id_Tarjeta = value; }
        }
        public Int16 Id_Cuenta
        {
            get { return id_Cuenta; }
            set { id_Cuenta = value; }
        }

        public String CodigoSeguridad
        {
            get { return codigoSeguridad; }
            set { codigoSeguridad = value; }
        }
        public Int16 Id_Tipo_Tarjeta
        {
            get { return id_Tipo_Tarjeta; }
            set { id_Tipo_Tarjeta = value; }
        }
        public String FechaEx
        {
            get { return fechaEx; }
            set { fechaEx = value; }
        }
        public String NumeroTarjeta
        {
            get { return numeroTarjeta; }
            set { numeroTarjeta = value; }
        }
        public Int16 Id_Institucion_Bancaria
        {
            get { return id_Institucion_Bancaria; }
            set { id_Institucion_Bancaria = value; }
        }
    }
}
