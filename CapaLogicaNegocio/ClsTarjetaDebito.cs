using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class ClsTarjetaDebito : ClsTarjeta
    {

        private String fechaEx;
        private String numeroTarjeta;

        public ClsTarjetaDebito() { }
        public ClsTarjetaDebito(String numeroTarjeta, String fechaEx, Int16 id_Cuenta, String codigoSeguridad, Int16 id_Tipo_Tarjeta, Int16 id_Institucion_Bancaria) : base(id_Cuenta, codigoSeguridad, id_Tipo_Tarjeta, id_Institucion_Bancaria)
        {
            this.fechaEx = fechaEx;
            this.numeroTarjeta = numeroTarjeta;
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



        ClsManejador M = new ClsManejador();

        public override String registrar()
        {
            string msj = "";

            List<ClsParametrosTarjeta> lst = new List<ClsParametrosTarjeta>();

            try
            {

                lst.Add(new ClsParametrosTarjeta(NumeroTarjeta, FechaEx, Id_Cuenta, CodigoSeguridad, Id_Tipo_Tarjeta, Id_Institucion_Bancaria));
                M.insertar_Tarjeta(lst);
                msj = "Insertado correctamente";
            }
            catch (Exception ex)
            {
                msj = "Error al insertar los datos";
                return msj;
            }

            return msj;
        }
      
        public override Tuple<List<Object>, SqlDataAdapter> listarTarjeta()
        {
            return M.listar_Tarjeta();
        }

        public override List<Object> buscarTarjeta(String numeroTarjeta)
        {
            return M.buscar_Tarjeta(numeroTarjeta);
        }
        public override void eliminarTarjeta(String numeroTarjeta)
        {
            if (buscarTarjeta(numeroTarjeta) != null)
                M.eliminar_Tarjeta(numeroTarjeta);
        }


        public List<Object> listarTipoC()
        {
            return M.ConsultarTipoC();
        }

        public List<Object> listarInsB()
        {
            return M.ConsultarInsB();
        }


        public override String actualizar(String numerocuenta)
        {
            List<ClsParametrosTarjeta> lst = new List<ClsParametrosTarjeta>();
            if (buscarTarjeta(numerocuenta) != null)
            {
                // lst.Add(new ClsParametros(Numerocuenta, Nombre, Apellido, CodigoSeguridad, InstitucionB, CodDebito));
               // M.actualizar_TD(numerocuenta, lst);
            }
            else
            {
                return "No se ha registrado una tarjeta con este número de cuenta.";
            }
            return "Datos actualizados.";
        }

    }
}

