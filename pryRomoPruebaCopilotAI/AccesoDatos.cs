using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryRomoPruebaCopilotAI
{
    public class AccesoDatos
    {
        private string _connectionString;

        public AccesoDatos()
        {
            string dbPath = Application.StartupPath + "..\\..\\..\\Base de Datos\\Clinica.accdb";
            //private static string rutaBD = "..\\..\\BaseDatos\\academia.accdb"; // Cambie la ruta si es necesario
            //return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={fullPath};Persist Security Info=False;";
            _connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath}";
        }

        public DataTable EjecutarConsulta(string query)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    connection.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar consulta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool EjecutarComando(string query)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar comando: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool VerificarConexion()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void CrearBaseDatos()
        {
            try
            {
                string dbPath = Application.StartupPath + @"\Base de Datos\Consultorio.mdb";
                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Base de Datos");

                if (!System.IO.File.Exists(dbPath))
                {
                    using (OleDbConnection connection = new OleDbConnection(_connectionString))
                    {
                        connection.Open();
                        
                        string[] tablas = new string[]
                        {
                            "CREATE TABLE Especialidades (ID_Especialidad COUNTER PRIMARY KEY, Nombre_Especialidad TEXT NOT NULL UNIQUE)",
                            "CREATE TABLE Medicos (Matricula TEXT PRIMARY KEY, Nombre_Completo TEXT NOT NULL)",
                            "CREATE TABLE Medico_Especialidad (Matricula TEXT, ID_Especialidad COUNTER, PRIMARY KEY (Matricula, ID_Especialidad), FOREIGN KEY (Matricula) REFERENCES Medicos(Matricula), FOREIGN KEY (ID_Especialidad) REFERENCES Especialidades(ID_Especialidad))"
                        };

                        foreach (string query in tablas)
                        {
                            using (OleDbCommand command = new OleDbCommand(query, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
