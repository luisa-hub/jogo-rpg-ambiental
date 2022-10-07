﻿using Assets.TCC.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerController : MonoBehaviour
{

    public TextMeshProUGUI mostra;
    public TMP_InputField consulta;
    public DatabaseDB banco;
    public TableController table; 
    //private DatabaseDB banco;

    void Awake()
    {
        banco = GetComponent<DatabaseDB>();
        Debug.Log(banco.ToString());
        table = GetComponent<TableController>();
    }
    public void click() {
        List<string> resultado = banco.Consultar(consulta.text);

        table.DefinirColunas(banco.colunas());

        mostra.text = string.Join(",", resultado.ToArray());

    
    }




}
