using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.TCC.Scripts;

public class PauseController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject botãoConfig;
    GameObject objeto;


    private void Start()
    {
        objeto = GameObject.Find("PauseMenu").transform.GetChild(0).gameObject;
    }
    
    public void pausa()
    {
        
        objeto.SetActive(true);

        //Para o jogador
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(false);
        GameObject.Find("Player").GetComponent<Player>().xInput = 0;
        GameObject.Find("Player").GetComponent<Player>().yInput = 0;
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(false);

        botãoConfig.SetActive(false);
    }

    // Update is called once per frame
    public void despausa()
    {
        objeto.SetActive(false);

        //Para o jogador
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(true);
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(true);

        botãoConfig.SetActive(true);
    }
}
