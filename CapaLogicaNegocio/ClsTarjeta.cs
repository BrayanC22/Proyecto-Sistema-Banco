using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
        public class ClsTarjeta
        {

        protected Int16 id_Tarjeta;
        protected Int16 id_Cuenta;
        protected String codigoSeguridad;
        protected Int16 id_Tipo_Tarjeta;
        protected Int16 id_Institucion_Bancaria;


        private List<Object> lst_obj;
        private SqlDataAdapter registro;

        public ClsTarjeta() { }
        public ClsTarjeta(Int16 id_Cuenta, String codigoSeguridad, Int16 id_Tipo_Tarjeta, Int16 id_Institucion_Bancaria)
        {
            // this.id_Tarjeta = id_Tarjeta;
            this.id_Cuenta = id_Cuenta;
            this.codigoSeguridad = codigoSeguridad;
            this.id_Tipo_Tarjeta = id_Tipo_Tarjeta;
            this.id_Institucion_Bancaria = id_Institucion_Bancaria;

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


        public Int16 Id_Institucion_Bancaria
        {
            get { return id_Institucion_Bancaria; }
            set { id_Institucion_Bancaria = value; }
        }


        public virtual String registrar() { return ""; }

        public virtual Tuple<List<Object>, SqlDataAdapter> listarTarjeta() { return Tuple.Create(lst_obj, registro); }

        public virtual List<Object> buscarTarjeta(String numeroTarjeta) { return lst_obj; }
        public virtual void eliminarTarjeta(String numeroTarjeta) { }
        public virtual String actualizar(String numeroTarjeta) { return ""; }
    }
    }


