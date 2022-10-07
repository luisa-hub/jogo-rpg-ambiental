using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerController : MonoBehaviour
{

    public TextMeshProUGUI mostra;
    public TMP_InputField consulta;
    public DatabaseDB banco;
    //private DatabaseDB banco;

    void Awake()
    {
        banco = GetComponent<DatabaseDB>();
        Debug.Log(banco.ToString());
    }
    public void click() {
        List<string> resultado = banco.Consultar(consulta.text);
        mostra.text = string.Join(",", resultado.ToArray());

    
    }




}
