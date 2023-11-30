using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaLogicaNegocio
{
    public class ClsPersona
    {
        protected String cedula;
        protected String nombre;
        protected Int16 edad;
        protected Int16 ciudad;
        protected String telefono;
        protected String sexo;

        private List<Object> lst_obj;
        private SqlDataAdapter registro;

        public ClsPersona() { }

        public ClsPersona(String cedula, String nombre, Int16 edad, Int16 ciudad, String sexo, String telefono)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.edad = edad;
            this.ciudad = ciudad;
            this.sexo = sexo;
            this.telefono = telefono;
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
      
        get { return edad ; }
            
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

        //Métodos que pueden ser modificados por las clases hijos
        public virtual String registrar() { return ""; }

        public virtual Tuple<List<Object>, SqlDataAdapter> listar() { return Tuple.Create(lst_obj, registro); }

        public virtual List<Object> buscar(String cedula) { return lst_obj; }
        public virtual void eliminar(String cedula) { }
    }

}

