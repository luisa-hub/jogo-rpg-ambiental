using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

/// <summary>
/// Faz a interação com o banco de dados, realizando consultas
/// </summary>
public class DatabaseDB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DisplayUsers();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayUsers()
    {
        //Debug.Log("oi");
        string dbName = "URI=file:" + Application.dataPath + "/Database/exemplo.db";
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            Debug.Log(dbName);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM USER";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log(reader["Nome"]);
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }

    }

    public List<string> Consultar(string consulta, string nome)
    {


        string dbName = "URI=file:" + Application.dataPath + "/Database/"+nome+".db";
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            
            Debug.Log(dbName);
            List<string> resultado = new List<string>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = consulta;
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //resultado.Add(reader["Nome"].ToString());
                    }
                    reader.Close();

                   
                }
            }
            connection.Close();
            return resultado;
        }


    }


    /// <summary>
    /// Método que pega o nome das colunas no banco de dados
    /// </summary>
    /// <returns>Retorna uma lista com o nome de todas as colunas do banco</returns>
    public List<string> colunas(string consulta, string nome)
    {
        
        Debug.Log("colunas");
        string dbName = "URI=file:" + Application.dataPath + "/Database/"+nome+".db";
        using (var connection = new SqliteConnection(dbName))
        {
            List<string> colunas = new List<string>();
            
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = consulta;

                using (IDataReader reader = command.ExecuteReader())
                {

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                         
                        colunas.Add(reader.GetName(i).ToString());
                        
                    }

                    reader.Close();
                }

            }
            connection.Close();
            return colunas;

        }
    }


    public List<IList<object>> dados(string consulta, string nome)
    {
        Debug.Log("dados");
        string dbName = "URI=file:" + Application.dataPath + "/Database/"+nome+".db";
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            List<IList<object>> dados = new List<IList<object>>();
            List<IList<string>> dados2 = new List<IList<string>>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = consulta;
                using (IDataReader reader = command.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        List<object> valores = new List<object>();
                        List<string> valores2 = new List<string>();
                        //para cada valor de cada coluna, adiciona o objeto numa lista de valores
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            valores.Add(reader.GetValue(i).ToString());
                            valores2.Add(reader.GetValue(i).ToString());
                        }

                        dados.Add(valores);
                        dados2.Add(valores2);

                    }
                    reader.Close();
                }
            }
            connection.Close();
            return dados;
        }

    }

}


