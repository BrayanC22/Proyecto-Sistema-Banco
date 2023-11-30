using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaAccesoDatos
{
    public class ClsManejador
    {

        private SqlConnection conexion;

        private SqlConnection abrir_conexion()
        {
            try
            {
                string ConnectionString = "server= localhost; database = proyecto_grupo5; integrated security = true  ";

                conexion = new SqlConnection(ConnectionString);
                conexion.Open();

                Console.WriteLine("Se abrio la conexion desde la capa de acceso a datos");

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return conexion;
        }

        private void cerrar_conexion(SqlConnection conexion)
        {
            conexion.Close();
            Console.WriteLine("Se cerro la conexion desde la capa de acceso a datos");
        }

        //Método para insertar información clientes
        public void insertar_cliente(List<ClsParametros> lst)
        {
            try
            {
              if (lst != null)
                {
                    SqlConnection conexion = abrir_conexion();
                    string cadena = "INSERT INTO Cliente" +
                                    "(Cedula, Nombre, Edad, Id_Ciudad, Sexo, Telefono, Id_Categoria,Imagen) " +
                                    "VALUES" + "(@Cedula, @Nombre, @Edad, @Id_Ciudad, @Sexo, @Telefono, @Id_Categoria, @Imagen)";

                    SqlCommand comannd = new SqlCommand(cadena, conexion);
               //     comannd.Parameters.AddWithValue("@Id_Cliente", lst[0].Id_Cliente);
                    comannd.Parameters.AddWithValue("@Cedula", lst[0].Cedula); 
                    comannd.Parameters.AddWithValue("@Nombre", lst[0].Nombre); 
                    comannd.Parameters.AddWithValue("@Edad", lst[0].Edad);
                    comannd.Parameters.AddWithValue("@Id_Ciudad", lst[0].Ciudad);
                    comannd.Parameters.AddWithValue("@Sexo", lst[0].Sexo);
                    comannd.Parameters.AddWithValue("@Telefono", lst[0].Telefono);
                    comannd.Parameters.AddWithValue("@Id_Categoria", lst[0].Categoria);
                    comannd.Parameters.AddWithValue("@Imagen", lst[0].Imagen);
                   

                    int t = Convert.ToInt32(comannd.ExecuteScalar()); 
                    cerrar_conexion(conexion);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error" );
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Faltan Datos " );
            }
        }

        public Tuple<List<Object>, SqlDataAdapter> listar_cliente()
        {
            List<Object> lstclientes = new List<Object>();

            SqlConnection conexion = abrir_conexion();
            string cadena = "Select c.Id_Cliente, c.Cedula, c.Nombre, c.Edad, cu.Nombre_Ciudad, c.Sexo,c.Telefono,t.Nombre_Cat,c.Imagen from Cliente c JOIN  Ciudad cu on c.Id_Ciudad=cu.Id_Ciudad JOIN Categoria t on c.Id_Categoria = t.Id_Categoria";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            SqlDataAdapter registro_adapter = new SqlDataAdapter(cadena, conexion);

            while (registros.Read())
            {
                var tmp = new
                {
                    id_cliente = Int16.Parse(registros["Id_Cliente"].ToString()),
                    cedula = registros["Cedula"].ToString(),
                    nombre = registros["Nombre"].ToString(),
                    edad = Int16.Parse(registros["Edad"].ToString()),
                    nombre_Ciudad = registros["Nombre_Ciudad"].ToString(),
                    sexo = registros["Sexo"].ToString(),
                    telefono = registros["Telefono"].ToString(),
                    nombre_Cat = registros["Nombre_Cat"].ToString(),
                    imagen = registros["Imagen"].ToString(),
                };

                lstclientes.Add(tmp);
            }
            cerrar_conexion(conexion);
            return Tuple.Create(lstclientes, registro_adapter);
        }


        public List<Object> buscar_cliente(String cedula)
        {
            List<Object> lstclientes = new List<Object>();

            SqlConnection conexion = abrir_conexion();
            string cadena = "Select c.Id_Cliente, c.Cedula, c.Nombre, c.Edad, cu.Nombre_Ciudad, c.Sexo,c.Telefono,t.Nombre_Cat,c.Imagen from Cliente c JOIN  Ciudad cu on c.Id_Ciudad=cu.Id_Ciudad JOIN Categoria t on c.Id_Categoria = t.Id_Categoria where Cedula =@cedula";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@cedula", cedula);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                var tmp = new
                {
                    id_cliente = Int16.Parse(registros["Id_Cliente"].ToString()),
                    cedula = registros["Cedula"].ToString(),
                    nombre = registros["Nombre"].ToString(),
                    edad = Int16.Parse(registros["Edad"].ToString()),
                    nombre_Ciudad = registros["Nombre_Ciudad"].ToString(),
                    sexo = registros["Sexo"].ToString(),
                    telefono = registros["Telefono"].ToString(),
                    nombre_Cat = registros["Nombre_Cat"].ToString(),
                    imagen = registros["Imagen"].ToString(),
                };
                lstclientes.Add(tmp);
            }
            cerrar_conexion(conexion);
            return lstclientes;
        }

        public int eliminar_cliente(String cedula)
        {
            SqlConnection conexion = abrir_conexion();
            string cadena = "DELETE FROM Cliente WHERE Cedula = @cedula";
            SqlCommand command = new SqlCommand(cadena, conexion);
            command.Parameters.AddWithValue("@cedula", cedula);
            int resultado = Convert.ToInt32(command.ExecuteScalar());

            MessageBox.Show("Se a eliminado con exito");

            cerrar_conexion(conexion);
            return resultado;
        }


        public List<Object> ConsultarCategoria()
        {
            List<Object> lstObjetos = new List<Object>();

            SqlConnection conexion = abrir_conexion();
            String cadena = "select Nombre_Cat from categoria";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                var tmp = new
                {
                    Nombre_Cat = registros["Nombre_Cat"].ToString()
                };
                lstObjetos.Add(tmp);
            }
            cerrar_conexion(conexion);
            return lstObjetos;
        }

        public List<Object> ConsultarCiudad()
        {
            List<Object> lstObjetos = new List<Object>();

            SqlConnection conexion = abrir_conexion();
            String cadena = "select Nombre_ciudad from ciudad";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                var tmp = new
                {
                    Nombre_ciudad = registros["Nombre_ciudad"].ToString()
                };
                lstObjetos.Add(tmp);
            }
            cerrar_conexion(conexion);
            return lstObjetos;
        }



        // Metodos para Cuentas
        public void insertar_cuenta(List<ClsParametrosCuenta> lst)
        {
            try
            {
                if (lst != null)
                {
                    SqlConnection conexion = abrir_conexion();
                    string cadena = "INSERT INTO Cuenta" +
                                    "(Id_Cliente, Cuenta_Cod_seguridad, Numero_Cuenta, Id_Tipo_Cuenta, Saldo_Inicial) " +
                                    "VALUES" + "(@Id_Cliente, @Cuenta_Cod_seguridad, @Numero_Cuenta, @Id_Tipo_Cuenta, @Saldo_Inicial)";

                    SqlCommand comannd = new SqlCommand(cadena, conexion);
                 //   comannd.Parameters.AddWithValue("@Id_Cuenta", lst[0].Id_Cuenta);
                    comannd.Parameters.AddWithValue("@Id_Cliente", lst[0].Id_Cliente); 
                    comannd.Parameters.AddWithValue("@Cuenta_Cod_seguridad", lst[0].Cod_seguridad);
                    comannd.Parameters.AddWithValue("@Numero_Cuenta", lst[0].Numero_Cuenta);
                    comannd.Parameters.AddWithValue("@Id_Tipo_Cuenta", lst[0].Id_Tipo_Cuenta);
                    comannd.Parameters.AddWithValue("@Saldo_Inicial", lst[0].SaldoInicial);

                    int t = Convert.ToInt32(comannd.ExecuteScalar());
                    cerrar_conexion(conexion);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public List<Object> ConsultarTipo()
        {
            List<Object> lstObjetos = new List<Object>();

            SqlConnection conexion = abrir_conexion();
            String cadena = "select Nombre_Tipo from Tipo_Cuenta";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                var tmp = new
                {
                    Nombre_Tipo = registros["Nombre_Tipo"].ToString()
                };
                lstObjetos.Add(tmp);
            }
            cerrar_conexion(conexion);
            return lstObjetos;
        }

        public Tuple<List<Object>, SqlDataAdapter> listar_cuenta()
        {
            List<Object> lstcuentas = new List<Object>();

            SqlConnection conexion = abrir_conexion();
            string cadena = " Select cu.Id_Cuenta, cli.Cedula , cli.Nombre, cu.Cuenta_Cod_seguridad, cu.Numero_Cuenta, ti.Nombre_Tipo,cu.Saldo_Inicial from Cuenta cu JOIN CLiente cli on cu.Id_Cliente = cli.Id_Cliente JOIN Tipo_Cuenta ti on cu.Id_Tipo_Cuenta = ti.Id_Tipo_Cuenta order by Id_Cuenta ";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();   
            SqlDataAdapter registro_adapter = new SqlDataAdapter(cadena, conexion);
            while (registros.Read())
            {
                var tmp = new
                {
                    id_Cuenta = Int16.Parse(registros["Id_Cuenta"].ToString()),
                    cedula = (registros["Cedula"].ToString()),
                    nombre = (registros["Nombre"].ToString()),
                    cuenta_Cod_seguridad = registros["Cuenta_Cod_seguridad"].ToString(),
                    numero_Cuenta = registros["Numero_Cuenta"].ToString(),
                    nombre_Tipo = registros["Nombre_Tipo"].ToString(),
                    saldo_Inicial = Double.Parse(registros["Saldo_Inicial"].ToString()),

                };

                lstcuentas.Add(tmp);
            }
            cerrar_conexion(conexion);
           
            return Tuple.Create(lstcuentas, registro_adapter);
        }

        public List<Object> buscar_cuenta(String numero_Cuenta)
        {
            List<Object> lstcuentas = new List<Object>();

            SqlConnection conexion = abrir_conexion();
            string cadena = "Select cu.Id_Cuenta, cli.Cedula , cli.Nombre, cu.Cuenta_Cod_seguridad, cu.Numero_Cuenta,ti.Nombre_Tipo,cu.Saldo_Inicial from Cuenta cu JOIN CLiente cli on cu.Id_Cliente = cli.Id_Cliente JOIN Tipo_Cuenta ti on cu.Id_Tipo_Cuenta = ti.Id_Tipo_Cuenta where Numero_Cuenta= @Numero_Cuenta ";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@Numero_Cuenta", numero_Cuenta);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                var tmp = new
                {
                    id_Cuenta = Int16.Parse(registros["Id_Cuenta"].ToString()),
                    cedula = (registros["Cedula"].ToString()),
                    nombre = (registros["Nombre"].ToString()),
                    cuenta_Cod_seguridad = registros["Cuenta_Cod_seguridad"].ToString(),
                    numero_Cuenta = registros["Numero_Cuenta"].ToString(),
                    nombre_Tipo = registros["Nombre_Tipo"].ToString(),
                    saldo_Inicial = Double.Parse(registros["Saldo_Inicial"].ToString()),

                };
                lstcuentas.Add(tmp);
            }
            cerrar_conexion(conexion);
            return lstcuentas;
        }

        public int eliminar_cuenta(String Numero_Cuenta)
        {
            SqlConnection conexion = abrir_conexion();
            string cadena = "DELETE FROM Cuenta WHERE Numero_Cuenta=@Numero_Cuenta";
            SqlCommand command = new SqlCommand(cadena, conexion);
            command.Parameters.AddWithValue("@Numero_Cuenta",Numero_Cuenta);
            int resultado = Convert.ToInt32(command.ExecuteScalar());

            MessageBox.Show("Se a eliminado con exito");

            cerrar_conexion(conexion);
            return resultado;
        }

        //Metodo para movimiento
        public int actualizar_cuenta_individual(String param_numero_Cuenta, Double param_saldoInicial)
        {
            SqlConnection conexion = abrir_conexion();
            string actualizar = "update Cuenta set Saldo_Inicial=@param_saldoInicial where Numero_Cuenta=@param_numero_Cuenta ";
            SqlCommand cmd = new SqlCommand(actualizar, conexion);
            cmd.Parameters.AddWithValue("@param_numero_Cuenta", param_numero_Cuenta);
            cmd.Parameters.AddWithValue("@param_saldoInicial", param_saldoInicial);
           
            int resultado_operacion = Convert.ToInt32(cmd.ExecuteScalar());
            cerrar_conexion(conexion);

            return resultado_operacion;
        }

        // Metodos para Tarjetas

        public void insertar_Tarjeta(List<ClsParametrosTarjeta> lst)
        {
            try
            {
                if (lst != null)
                {
                    SqlConnection conexion = abrir_conexion();
                    string cadena = "INSERT INTO Tarjeta" +
                                    "(NumeroTarjeta,FechaExpedicion,Id_Cuenta,Cod_seguridad,Id_Tipo_Tarjeta,Id_Institucion_Bancaria) " +
                                    "VALUES" + "(@NumeroTarjeta, @FechaExpedicion, @Id_Cuenta, @Cod_seguridad, @Id_Tipo_Tarjeta,@Id_Institucion_Bancaria)";

                    SqlCommand comannd = new SqlCommand(cadena, conexion);
                 //   comannd.Parameters.AddWithValue("@Id_Tarjeta", lst[0].Id_Tarjeta);
                    comannd.Parameters.AddWithValue("@NumeroTarjeta", lst[0].NumeroTarjeta); // a la variable de tip Mysql comand agregar un valor al parametro
                    comannd.Parameters.AddWithValue("@FechaExpedicion", lst[0].FechaEx); // Parametro a remplazar en la cadena de conxion o insert , con lo que venga de la capa logica
                    comannd.Parameters.AddWithValue("@Id_Cuenta", lst[0].Id_Cuenta);
                    comannd.Parameters.AddWithValue("@Cod_seguridad", lst[0].CodigoSeguridad);
                    comannd.Parameters.AddWithValue("@Id_Tipo_Tarjeta", lst[0].Id_Tipo_Tarjeta);
                    comannd.Parameters.AddWithValue("@Id_Institucion_Bancaria", lst[0].Id_Institucion_Bancaria);

                    int t = Convert.ToInt32(comannd.ExecuteScalar());
                    cerrar_conexion(conexion);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public Tuple<List<Object>, SqlDataAdapter> listar_Tarjeta()
        {
            List<Object> lsttarjeta = new List<Object>();

            SqlConnection conexion = abrir_conexion();
            string cadena = "Select t.id_tarjeta, t.NumeroTarjeta , t.FechaExpedicion, c.Numero_Cuenta ,t.Cod_seguridad, ti.Nombre_Tipo,i.Nombre_Ib from Tarjeta t JOIN  Cuenta c on t.Id_Cuenta  = c.Id_Cuenta  JOIN Tipo_Tarjeta ti on t.Id_Tipo_Tarjeta = ti.Id_Tipo_Tarjeta JOIN Institucion_Bancaria i on t.Id_Institucion_Bancaria  = i.Id_Institucion_Bancaria";
           SqlCommand comando = new SqlCommand(cadena, conexion);
           SqlDataReader registros = comando.ExecuteReader();
            SqlDataAdapter registro_adapter = new SqlDataAdapter(cadena, conexion);
            while (registros.Read())
            {
                var tmp = new
                {
                    id_tarjeta = Int16.Parse(registros["Id_Tarjeta"].ToString()),
                    numeroTarjeta = registros["NumeroTarjeta"].ToString(),
                    fechaExpedicion = registros["FechaExpedicion"].ToString(),
                    numero_Cuenta = registros["Numero_Cuenta"].ToString(),
                    cod_seguridad = Int16.Parse(registros["Cod_seguridad"].ToString()),
                    nombre_Tipo = registros["Nombre_Tipo"].ToString(),
                    nombre_Ib = registros["Nombre_Ib"].ToString(),
                };

                lsttarjeta.Add(tmp);
            }
            cerrar_conexion(conexion);
            return Tuple.Create(lsttarjeta, registro_adapter);
        }

        public List<Object> buscar_Tarjeta(String numeroTarjeta)
        {
            List<Object> lsttarjeta = new List<Object>();

            SqlConnection conexion = abrir_conexion();
            string cadena = "Select t.Id_Tarjeta, t.NumeroTarjeta , t.FechaExpedicion, c.Numero_Cuenta ,t.Cod_seguridad, ti.Nombre_Tipo,i.Nombre_Ib from Tarjeta t JOIN  Cuenta c on t.Id_Cuenta  = c.Id_Cuenta  JOIN Tipo_Tarjeta ti on t.Id_Tipo_Tarjeta = ti.Id_Tipo_Tarjeta JOIN Institucion_Bancaria i on t.Id_Institucion_Bancaria  = i.Id_Institucion_Bancaria WHERE NumeroTarjeta =@NumeroTarjeta";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                var tmp = new
                {
                    id_tarjeta = Int16.Parse(registros["Id_Tarjeta"].ToString()),
                    numeroTarjeta = registros["NumeroTarjeta"].ToString(),
                    fechaExpedicion = registros["FechaExpedicion"].ToString(),
                    numero_Cuenta = registros["Numero_Cuenta"].ToString(),
                    cod_seguridad = Int16.Parse(registros["Cod_seguridad"].ToString()),
                    nombre_Tipo = registros["Nombre_Tipo"].ToString(),
                    nombre_Ib = registros["Nombre_Ib"].ToString(),
                };
                lsttarjeta.Add(tmp);
            }
            cerrar_conexion(conexion);
            return lsttarjeta;
        }

        public int eliminar_Tarjeta(String NumeroTarjeta)
        {
            SqlConnection conexion = abrir_conexion();
            string cadena = "DELETE FROM Tarjeta WHERE  NumeroTarjeta=@NumeroTarjeta";
            SqlCommand command = new SqlCommand(cadena, conexion);
            command.Parameters.AddWithValue("@NumeroTarjeta", NumeroTarjeta);
            int resultado = Convert.ToInt32(command.ExecuteScalar());

            MessageBox.Show("Se a eliminado con exito");

            cerrar_conexion(conexion);
            return resultado;
        }

        public List<Object> ConsultarTipoC()
        {
            List<Object> lstObjetos = new List<Object>();

            SqlConnection conexion = abrir_conexion();
            String cadena = "select Nombre_Tipo from Tipo_Tarjeta";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                var tmp = new
                {
                    Nombre_Tipo = registros["Nombre_Tipo"].ToString()
                };
                lstObjetos.Add(tmp);
            }
            cerrar_conexion(conexion);
            return lstObjetos;
        }
        public List<Object> ConsultarInsB()
        {
            List<Object> lstObjetos = new List<Object>();

            SqlConnection conexion = abrir_conexion();
            String cadena = "select Nombre_Ib from Institucion_Bancaria";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                var tmp = new
                {
                    Nombre_Ib = registros["Nombre_Ib"].ToString()
                };
                lstObjetos.Add(tmp);
            }
            cerrar_conexion(conexion);
            return lstObjetos;
        }

    }
 }
   