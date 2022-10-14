using Assets.TCC.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.ComponentModel;
using System;
using Mono.Data.Sqlite;
using UnityEngine.UI;

/// <summary>
/// Computador é o controlador do banco de dados e do componente da tabela WDataTable
/// </summary>
public class ComputerController : MonoBehaviour
{

    public TextMeshProUGUI mostra;
    public TMP_InputField consulta;
    public DatabaseDB banco;
    public TableController table;
    public Button botaoTip;
    private string messagemDeErro;
    public TextMeshProUGUI textoErro;
    public QuestsController quest;
    //private DatabaseDB banco;

    void Awake()
    {
        banco = GetComponent<DatabaseDB>();
        Debug.Log(banco.ToString());
        table = GetComponent<TableController>();
        //quest = GetComponent<QuestsController>();
        
        
    }

    public void click() {

        try
        {
            List<string> resultado = banco.Consultar(consulta.text, "exemplo");

            quest.verifyData(banco.colunas(consulta.text, "exemplo"), banco.dados(consulta.text, "exemplo"));

            table.MontarTabela(banco.colunas(consulta.text, "exemplo"), banco.dados(consulta.text, "exemplo"));

            mostra.text = string.Join(",", resultado.ToArray());
            botaoTip.gameObject.SetActive(false);
           
        }
        catch (SqliteException ex) 
        {
            if (ex.ErrorCode == SQLiteErrorCode.Error)
            {
                mostra.text =  "Parece que você digitou algo errado!";

                messagemDeErro = ex.Message;
                botaoTip.gameObject.SetActive(true);
                
            }

           
            
            if (ExceptionContainsErrorCode(ex, 80004005))
            {
                Debug.Log(ex);
                mostra.text = string.Join(",", ex.Message);
            }
            
        }
    
    }

    public void fechar()
    {
         this.gameObject.SetActive(false);

        table.reset();

        //Volta
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(true);
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(true);
    }

    public void tip()
    {
        textoErro.SetText(messagemDeErro);
        

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
