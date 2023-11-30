using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;


namespace CapaLogicaNegocio
{
    public class ClsCuenta
    {
        private Int16 id_Cuenta;
        private Int16 id_Cliente;
        private String cod_seguridad;
        private String numero_Cuenta;
        private Int16 id_Tipo_Cuenta;
        private Double saldoInicial;
        private String numcuen;

        ClsManejador M = new ClsManejador();

        public ClsCuenta( )
        {
            
        }


        public ClsCuenta(Int16 id_Cliente, String cod_seguridad, String numero_Cuenta, Int16 id_Tipo_Cuenta, Double saldoInicial)
        {
         //   this.id_Cuenta = id_Cuenta;
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

        //Registrar cuenta        
        public String registrarcuenta()
        {
            string msj = "";

            //Lista genérica de parámetros
            List<ClsParametrosCuenta> lst = new List<ClsParametrosCuenta>();

            try
            {
                //Pasar los parámetros hacia la capa de acceso a datos
                lst.Add(new ClsParametrosCuenta(Id_Cliente, Cod_seguridad, Numero_Cuenta, Id_Tipo_Cuenta, SaldoInicial));
                M.insertar_cuenta(lst);
                msj = "Insertado correctamente";
            }
            catch (Exception)
            {
                msj = "Error al insertar los datos";
                return msj;
            }

            return msj;
        }

        //Lista cuenta
        public Tuple<List<Object>, SqlDataAdapter> listar()
        {
            return M.listar_cuenta();
        }


        public Object buscar(String numcuenta)
        {
            return M.buscar_cuenta(numcuenta);
        }
        public void elimina(String numcuenta)
        {
            if (buscar(numcuenta) != null)
                M.eliminar_cuenta(numcuenta);
        }

        public override string ToString()
        {
            return "\nCedula del Cliente: " + Id_Cuenta + "\nNombre del Cliente: " + Id_Cliente + "\nCodigo: " + Cod_seguridad + "\nNumero Cuenta: " + Numero_Cuenta + "\nTipo Cuenta: " + Id_Tipo_Cuenta + "\nSaldo: " + SaldoInicial;
        }


        public  int actualizar_x_numerocuenta( String numero_Cuenta, Double saldoInicial)
        {
            return M.actualizar_cuenta_individual( numero_Cuenta,  saldoInicial);
        }

        public List<Object> listarTipo()
        {
            return M.ConsultarTipo();
        }
    }

   

}
