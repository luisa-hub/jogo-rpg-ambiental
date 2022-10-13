using Assets.TCC.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.ComponentModel;
using System;

/// <summary>
/// Computador é o controlador do banco de dados e do componente da tabela WDataTable
/// </summary>
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

        try
        {
            List<string> resultado = banco.Consultar(consulta.text);

            table.MontarTabela(banco.colunas(consulta.text), banco.dados(consulta.text));

            mostra.text = string.Join(",", resultado.ToArray());
           
        }
        catch (System.Exception ex) 
        {

            if (ExceptionContainsErrorCode(ex, 80004005))
            {
                Debug.Log(ex);
                mostra.text = string.Join(",", ex.Message);
            }
            
        }
    
    }

    public void fechar()
    {
         GetComponent<ComputerController>().gameObject.SetActive(false);

        //Volta
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(true);
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(true);
    }

    private bool ExceptionContainsErrorCode(Exception e, int ErrorCode)
    {
        Win32Exception winEx = e as Win32Exception;
        if (winEx != null && ErrorCode == winEx.ErrorCode)
            return true;

        if (e.InnerException != null)
            return ExceptionContainsErrorCode(e.InnerException, ErrorCode);

        return false;
    }


}
