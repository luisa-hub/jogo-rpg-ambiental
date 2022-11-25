using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowController : MonoBehaviour
{
    public string janela;
    private GameObject objeto;
    private TMP_InputField input;
    public string banco;

    // Start is called before the first frame update
    void Start()
    {

        objeto = GameObject.Find(janela).transform.GetChild(0).gameObject;
        input = objeto.GetComponent<ComputerController>().input;

    }


    public void InitInteraction()
    {
        objeto.SetActive(true);

        input.Select();

        objeto.GetComponent<ComputerController>().bancoPrimario = banco;

   }

    public void click()
    {
        objeto.SetActive(false);
        Player.Instance.PlayerReturnInteraction();

    }


}

