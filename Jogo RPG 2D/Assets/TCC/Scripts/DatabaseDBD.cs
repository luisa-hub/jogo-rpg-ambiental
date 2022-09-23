using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Mono.Data.Sqlite;
using System.Data;  

public class DatabaseDBD : MonoBehaviour
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
        string dbName = "URI=file:" + Application.dataPath + "/Database/exemplo.db";
        using (var connection = new SqliteConnection(dbName)) 
        {
            connection.Open();
            Debug.Log(dbName);
            /*
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
            } */
            connection.Close();
        }
        
    }
    
}
