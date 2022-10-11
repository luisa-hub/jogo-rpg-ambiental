using Assets.TCC.Scripts;
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

        table.MontarTabela(banco.colunas(), banco.dados());
    }

    public void click() {

        try
        {
            List<string> resultado = banco.Consultar(consulta.text);
            

            mostra.text = string.Join(",", resultado.ToArray());
           
        }
        catch (System.Exception ex)
        {
            mostra.text = string.Join(",", ex.Message);
        }
    
    }




}
