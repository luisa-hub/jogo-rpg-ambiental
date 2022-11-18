using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.TCC.Scripts;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject botãoConfig;
    public GameObject janelaCreditos;
    GameObject objeto;
    int pausado = 0;
    private bool verificaMovimentoAnterior = true;

    private void Start()
    {
        objeto = GameObject.Find("PauseMenu").transform.GetChild(0).gameObject;
    }
    
    public void pausa()
    {
        
        objeto.SetActive(true);

        if (!GameObject.Find("Player").GetComponent<Player>().canMove)
            verificaMovimentoAnterior = false;
        else
            verificaMovimentoAnterior = true;

        //Para o jogador
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(false);
        GameObject.Find("Player").GetComponent<Player>().xInput = 0;
        GameObject.Find("Player").GetComponent<Player>().yInput = 0;
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(false);

        botãoConfig.SetActive(false);
        pausado = 1;
    }

    // Update is called once per frame
    public void despausa()
    {
        objeto.SetActive(false);

        if (verificaMovimentoAnterior)
            //Para o jogador
            GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(true);
        
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(true);

        botãoConfig.SetActive(true);
        pausado = 0;
    }

    public void esc() {
        if (pausado == 0)
        {
            pausa();
        }
        else {
            despausa();
        }
    
    
    }


    public void creditos() {

        janelaCreditos.SetActive(true);
    }

    public void fechaCreditos() {
        janelaCreditos.SetActive(false);
    }

    public void menu() {
        SceneManager.LoadScene(0);



    }

    public void sair() {

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
