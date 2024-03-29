﻿using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

/// <summary>
/// Faz a interação com o banco de dados, realizando consultas
/// </summary>
public class DatabaseController : MonoBehaviour
{

    /// <summary>
    /// Método que pega o nome das colunas no banco de dados
    /// </summary>
    /// <returns>Retorna uma lista com o nome de todas as colunas do banco</returns>
    public List<string> colunas(string consulta, string nome)
    {

        string dbName = "URI=file:" + Application.dataPath + "/Database/"+ nome +".db";
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
                         
                        colunas.Add(reader.GetName(i));
                        
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
  
        string dbName = "URI=file:" + Application.dataPath + "/Database/"+ nome +".db";
        using (var connection = new SqliteConnection(dbName))
        {

            connection.Open();

            List<IList<object>> dados = new List<IList<object>>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = consulta;
                using (IDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        List<object> valores = new List<object>();
                        //para cada valor de cada coluna, adiciona o objeto numa lista de valores
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader.GetValue(i).GetType().ToString() == "System.DBNull")
                                valores.Add(reader.GetValue(i).ToString());
                            else
                            {
                                valores.Add(reader.GetValue(i));
                            }

                            }

                        dados.Add(valores);

                    }
                    reader.Close();
                }
            }
            connection.Close();
            return dados;
        }

    }

    public void consulta(string consulta, string nome)
    {

        string dbName = "URI=file:" + Application.dataPath + "/Database/" + nome + ".db";
        using (var connection = new SqliteConnection(dbName))
        {
            List<string> colunas = new List<string>();

            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = consulta;
                IDataReader reader = command.ExecuteReader();
                reader.Close();

            }
            connection.Close();
            return;
        }
    }


}


