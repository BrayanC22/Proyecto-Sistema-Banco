using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class ClsClientes : ClsPersona
    {
        private Int16 categoria;
        private String imagen;
        private Int16 id_Cliente;
        

        public ClsClientes()
        {

        }
        public ClsClientes(String cedula, String nombre, Int16 edad, Int16 ciudad, String sexo, String telefono, Int16 categoria, String imagen) : base(cedula, nombre, edad, ciudad, sexo, telefono)
        {
            //this.id_Cliente = id_Cliente;
            this.categoria = categoria;
            this.imagen = imagen;
        }

        public Int16 Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        public String Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public Int16 Id_Cliente
        {
            get { return id_Cliente; }
            set { id_Cliente = value; }
        }


        ClsManejador M = new ClsManejador();

        public override String registrar()
        {
            string msj = "";


            //Lista genérica de parámetros
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                //Pasar los parámetros hacia la capa de acceso a datos
                lst.Add(new ClsParametros(Cedula, Nombre, Edad, Ciudad, Sexo, Telefono, Categoria, Imagen));
                M.insertar_cliente(lst);
                msj = "Insertado correctamente";
            }
            catch (Exception ex)
            {
                msj = "Error al insertar los datos";
                return msj;
            }

            return msj;
        }

        //Lista alumnos

        public override Tuple<List<Object>, SqlDataAdapter> listar()
        {
            return M.listar_cliente();
        }

        public override List<Object> buscar(String cedula)
        {
            return M.buscar_cliente(cedula);
        }
        public override void eliminar(String cedula)
        {
            if (buscar(cedula) != null)
                M.eliminar_cliente(cedula);
        }


        public int Retiro()
        {
            int retiro = 0, fondos = 0;
            bool efectivo = true;
            while (!efectivo)
            {
                if (fondos > 0)
                {
                    efectivo = true;
                }
                else
                    if (fondos <= 0)
                {
                    efectivo = false;
                }
            }
            if (efectivo == false)
            {
                Console.WriteLine("Fondos insuficientes.");
            }

            return retiro;
        }

        public List<Object> listarCiudad()
        {
            return M.ConsultarCiudad();
        }

        public List<Object> listarCategoria()
        {
            return M.ConsultarCategoria();
        }

    }
}