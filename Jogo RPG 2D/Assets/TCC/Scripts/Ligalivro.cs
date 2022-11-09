using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ligalivro : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject botãoLivro;
    public GameObject objeto;


    private void Start()
    {
        //objeto = GameObject.Find("LivroCanvas").transform.GetChild(0).gameObject;
  

    }

    public void abre()
    {

        objeto.SetActive(true);

        //Para o jogador
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(false);
        GameObject.Find("Player").GetComponent<Player>().xInput = 0;
        GameObject.Find("Player").GetComponent<Player>().yInput = 0;
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(false);

        botãoLivro.SetActive(false);
    }

    // Update is called once per frame
    public void fecha()
    {
        objeto.SetActive(false);

        //Para o jogador
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(true);
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(true);

        botãoLivro.SetActive(true);
    }
}
