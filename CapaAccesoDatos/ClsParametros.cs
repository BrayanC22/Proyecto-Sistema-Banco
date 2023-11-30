using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{

    public class ClsParametros
    {
        private Int16 id_Cliente;
        private string cedula;
        private string nombre;
        private Int16 edad;
        private Int16 ciudad;
        private string telefono;
        private string sexo;
        private Int16 categoria;
        private string imagen;
       
        //Clientes

        public ClsParametros(string cedula, string nombre, Int16 edad, Int16 ciudad, string sexo, string telefono, Int16 categoria, String imagen)
        {
           // this.id_Cliente = id_Cliente;
            this.cedula = cedula;
            this.nombre = nombre;
            this.edad = edad;
            this.ciudad = ciudad;
            this.telefono = telefono;
            this.sexo = sexo;
            this.categoria = categoria;
            this.imagen = imagen;

        }

        public Int16 Id_Cliente
        {
            get { return id_Cliente; }
            set { id_Cliente = value; }
        }

        public String Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Int16 Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public Int16 Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public String Sexo
        {
            get { return sexo; }
            set { sexo = value; }
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
    }
}
