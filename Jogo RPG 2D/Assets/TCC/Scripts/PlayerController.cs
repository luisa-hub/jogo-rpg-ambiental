using Assets.TCC.Scripts;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    private bool _canInteract = true;
    private GameObject lastGameObjectWithCollision;
    private List<GameObject> listaColisoes;
    public List<string> flagMissoesConcluidas;
    NPCController nPCController;
    WindowController windowController;
    DoorController porta;
    public GameObject enter;
    public PauseController pause;
    public VanishController vanishController;
    public NewsController googli;
    public BookController livro1;
    public BookController livro2;
    public NewsController newsController;
    public bool desbloqueouBotoes;
    public NPCController narrador;

    private void Awake()
    {
        _canInteract = true;
    }

    private void Start()
    {
        Player.Instance.PlayerPauseInteraction();
        narrador.InitInteraction(flagMissoesConcluidas);
        listaColisoes = new List<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        // Se o jogador puder interagir e tirver pressionado enter
        if (CanInteractAndPressEnter())
        {
            if (isNpcObject())
            {
                nPCController = ultimoObjeto().GetComponent<NPCController>();
                Player.Instance.PlayerPauseInteraction();
                nPCController.InitInteraction(flagMissoesConcluidas);
            }

            if (isComputerObject())
            {
                windowController = ultimoObjeto().GetComponent<WindowController>();
                Player.Instance.PlayerPauseInteraction();
                windowController.InitInteraction();
            }

            if (isDoorObject())
            {
                porta = ultimoObjeto().GetComponent<DoorController>();
                bool aberto = porta.InitInteraction(flagMissoesConcluidas);
                if (!aberto) { Player.Instance.PlayerPauseInteraction(); }
            }
        }

        EnterInteractionSprite();

        if (OpenPauseMenu())
            pause.esc();

        if (desbloqueouBotoes) {

            if (Tpressured() && googli.isOpen)
                googli.fecha();
            else if (Tpressured() && _canInteract)
                googli.abre();

            if (Epressured() && livro1.isOpen)
                livro1.fecha();
            else if (Epressured() && _canInteract)
                livro1.abre();

            if (Rpressured() && livro2.isOpen)
                livro2.fecha();
            else if (Rpressured() && _canInteract)
                livro2.abre();


        }


    }

    private GameObject ultimoObjeto() {
        //return lastGameObjectWithCollision;
        GameObject retornar;
        try { retornar = listaColisoes.Last(); }
        catch  {
            retornar = null;
        }
        
        return retornar;
    }

    private static bool OpenPauseMenu()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    private static bool Tpressured() {
        return Input.GetKeyDown(KeyCode.T);
    }

    private static bool Epressured()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private static bool Rpressured()
    {
        return Input.GetKeyDown(KeyCode.R);
    }

    private bool CanInteractAndPressEnter()
    {
        return _canInteract && Input.GetKeyDown(KeyCode.Return);
    }

    private bool isDoorObject()
    {
        return ultimoObjeto() && ultimoObjeto().tag.Equals("Porta");
    }

    private bool isComputerObject()
    {
        return ultimoObjeto() && ultimoObjeto().tag.Equals("Computador");
    }

    private bool isNpcObject()
    {
        return ultimoObjeto() && ultimoObjeto().tag.Equals("NPC");
    }

    private void EnterInteractionSprite()
    {
        if (ultimoObjeto() != null
                    && _canInteract
                    && (ultimoObjeto().tag.Equals("NPC")
                    || ultimoObjeto().tag.Equals("Computador")
                    || ultimoObjeto().tag.Equals("Porta")))
        {

            enter.GetComponent<SpriteRenderer>().enabled = true;

        }

        else
        {
            enter.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void CanInteract(bool status)
    {
        _canInteract = status;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Computador") 
            || collision.gameObject.tag.Equals("NPC") 
            || collision.gameObject.tag.Equals("Porta"))

        //lastGameObjectWithCollision = collision.gameObject;
        listaColisoes.Add(collision.gameObject);
        //Debug.Log("colocado");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject == ultimoObjeto()) {
        listaColisoes.Remove(collision.gameObject);
        /*
            if (listaColisoes.Remove(collision.gameObject)) {
                if (listaColisoes.Count > 0)
                {
                    Debug.Log("removido");
                    lastGameObjectWithCollision = listaColisoes.Last();
                    Debug.Log(listaColisoes.Count);
                }
            }
            else { 
            
            lastGameObjectWithCollision = null;
                Debug.Log("anulado");
            }
        */

        //}

    }

    public void updateTags(string novaTag) {
        if (flagMissoesConcluidas.Contains(novaTag)==false) {
            flagMissoesConcluidas.Add(novaTag);
            vanishController.acoes();
            newsController.atualizar(novaTag);
        }


    }


}
