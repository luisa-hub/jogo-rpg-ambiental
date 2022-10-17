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
    

    void Awake()
    {
        banco = GetComponent<DatabaseDB>();
        table = GetComponent<TableController>();
        
        
    }

    public void click() {

        try
        {
            List<string> colunas = banco.colunas(consulta.text, "exemplo");
            List <IList<object>> linhas = banco.dados(consulta.text, "exemplo");

            quest.verifyData(colunas, linhas);

            table.MontarTabela(colunas, linhas);

            botaoTip.gameObject.SetActive(false);
            mostra.text = "";
           
        }
        catch (SqliteException ex) 
        {
            if (ex.ErrorCode == SQLiteErrorCode.Error)
            {
                mostra.text =  "Parece que você digitou algo errado!";

                messagemDeErro = ex.Message;
                botaoTip.gameObject.SetActive(true);
                
            }
            
        }
        catch (NullReferenceException)
        {
            mostra.text = "Cuidado, não clique levianamente em botões...!";
        }
    
    }

    public void fechar()
    {
         this.gameObject.SetActive(false);

        table.reset();
        mostra.text = "";
        botaoTip.gameObject.SetActive(false);

        //Retorna movimento ao Player
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(true);
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(true);
    }

    public void tip()
    {
        textoErro.SetText(messagemDeErro);
        botaoTip.gameObject.SetActive(false);

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
