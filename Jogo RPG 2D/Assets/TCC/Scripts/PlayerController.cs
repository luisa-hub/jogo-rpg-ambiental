using Assets.TCC.Scripts;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _canInteract = true;
    private GameObject lastGameObjectWithCollision;
    public List<string> flagMissoesConcluidas;
    NPCController nPCController;
    WindowController windowController;
    DoorController porta;
    public GameObject enter;
    public PauseController pause;
    public VanishController vanishController;

    private void Awake()
    {
        _canInteract = true;
    }
    // Update is called once per frame
    void Update()
    {
        // Se o jogador puder interagir e tirver pressionado enter
        if (CanInteractAndPressEnter())
        {
            if (NpcObject())
            {
                nPCController = lastGameObjectWithCollision.GetComponent<NPCController>();
                Player.Instance.PlayerPauseInteraction();
                nPCController.InitInteraction(flagMissoesConcluidas);

            }

            if (ComputerObject())
            {
                windowController = lastGameObjectWithCollision.GetComponent<WindowController>();
                Player.Instance.PlayerPauseInteraction();
                windowController.InitInteraction();

            }

            if (DoorObject())
            {
                porta = lastGameObjectWithCollision.GetComponent<DoorController>();
                porta.InitInteraction(flagMissoesConcluidas);
            }
        }

        //Responsável pela Sprite de Enter que aparece na tela
        EnterInteractionSprite();

        if (OpenPauseMenu())
        {
            pause.esc();
            

        }


    }

    private static bool OpenPauseMenu()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    private bool CanInteractAndPressEnter()
    {
        return _canInteract && Input.GetKeyDown(KeyCode.Return);
    }

    private bool DoorObject()
    {
        return lastGameObjectWithCollision && lastGameObjectWithCollision.tag.Equals("Porta");
    }

    private bool ComputerObject()
    {
        return lastGameObjectWithCollision && lastGameObjectWithCollision.tag.Equals("Computador");
    }

    private bool NpcObject()
    {
        return lastGameObjectWithCollision && lastGameObjectWithCollision.tag.Equals("NPC");
    }

    private void EnterInteractionSprite()
    {
        if (lastGameObjectWithCollision != null
                    && _canInteract
                    && (lastGameObjectWithCollision.tag.Equals("NPC")
                    || lastGameObjectWithCollision.tag.Equals("Computador")
                    || lastGameObjectWithCollision.tag.Equals("Porta")))
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

        lastGameObjectWithCollision = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == lastGameObjectWithCollision)
            lastGameObjectWithCollision = null;
    }

    public void updateTags(string novaTag) {
        if (flagMissoesConcluidas.Contains(novaTag)==false) {
            flagMissoesConcluidas.Add(novaTag);
            vanishController.acoes();
        }


    }


}
