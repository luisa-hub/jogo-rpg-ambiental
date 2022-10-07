using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Mono.Data.Sqlite;
using System.Data;
using WDT;

public class DatabaseDB: MonoBehaviour
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
            
            using(var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM USER";
                using (IDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read()) {
                        Debug.Log(reader["Nome"]);
                    }
                    reader.Close();
                }
            } 
            connection.Close();
        }
        
    }

    public List<string> Consultar(string consulta) {
        string dbName = "URI=file:" + Application.dataPath + "/Database/exemplo.db";
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
                        reader.GetValue(1);
                        resultado.Add(reader["Nome"].ToString()); 
                    }
                    reader.Close();
                }
            }
            connection.Close();
            return resultado;
        }


    }

    public List<string> colunas()
    {
        string dbName = "URI=file:" + Application.dataPath + "/Database/exemplo.db";
        using (var connection = new SqliteConnection(dbName))
        {
            var i = 0;
            connection.Open();
            Debug.Log(dbName);
            List<string> resultado = new List<string>();

            using (var command = connection.CreateCommand())
            {
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                        resultado.Add(reader.GetValue(i).ToString());
                        i++;
                    }
                    reader.Close();
                }
            }
            connection.Close();
            return resultado;
        }

    }

    public string[][] dados(string consulta)
    {
        string dbName = "URI=file:" + Application.dataPath + "/Database/exemplo.db";
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            Debug.Log(dbName);
            int i = 0;
            // List<List<string>> resultado = new List<List<string>>();
            Dictionary<string, List<string>> resultado = new Dictionary<string, List< string >> ();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = consulta;
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Precisamos pegar nome da coluna, e dado delas. reader.read itera por cada linha, precisamos iterar por coluna
                        List<string> valores = new List<string>();
                        valores.Add(reader.ToString());

                        resultado.Add(reader.GetValue(i).ToString(), valores);
                        i++;
                    }
                    reader.Close();
                }
            }
            connection.Close();
            return resultado;
        }

    }

}

