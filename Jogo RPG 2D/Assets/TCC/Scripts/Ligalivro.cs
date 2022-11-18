using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ligalivro : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject botaoLivro;
  
    public GameObject objeto;


    public void abre()
    {

        objeto.SetActive(true);

        //Para o jogador
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(false);
        GameObject.Find("Player").GetComponent<Player>().xInput = 0;
        GameObject.Find("Player").GetComponent<Player>().yInput = 0;
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(false);

        botaoLivro.SetActive(false);
    }

    // Update is called once per frame
    public void fecha()
    {
        objeto.SetActive(false);

        //Para o jogador
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(true);
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(true);

        botaoLivro.SetActive(true);
    }
}
