using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerController : MonoBehaviour
{

    public TextMeshProUGUI mostra;
    public TMP_InputField consulta;
    private DatabaseDB banco;

    //banco = this.getComponent(typeof(DatabaseDB)) as DatabaseDB;
    public void click() {
        mostra.text = consulta.text;

    
    }




}
