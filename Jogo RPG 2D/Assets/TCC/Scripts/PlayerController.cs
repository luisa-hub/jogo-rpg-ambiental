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
    Porta porta;
    public GameObject enter;
    public PauseController pause;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Se o jogador puder interagir e tirver pressionado enter
        if (_canInteract && Input.GetKeyDown(KeyCode.Return))
        {
            // Verificar se o objeto interagido é um NPC
            if (lastGameObjectWithCollision && lastGameObjectWithCollision.tag.Equals("NPC"))
            {
                // Inicia a interação com o NPCController
                nPCController = lastGameObjectWithCollision.GetComponent<NPCController>();
                Debug.Log(flagMissoesConcluidas);
                nPCController.InitInteraction(flagMissoesConcluidas);
                
            }

            if (lastGameObjectWithCollision && lastGameObjectWithCollision.tag.Equals("Computador"))
            {
                windowController = lastGameObjectWithCollision.GetComponent<WindowController>();
                windowController.InitInteraction();
            }

            if (lastGameObjectWithCollision && lastGameObjectWithCollision.tag.Equals("Porta"))
            {
                porta = lastGameObjectWithCollision.GetComponent<Porta>();
                porta.InitInteraction();
            }
        }
        if (lastGameObjectWithCollision != null && _canInteract) { 
        if (_canInteract && (lastGameObjectWithCollision.tag.Equals("NPC") || lastGameObjectWithCollision.tag.Equals("Computador") || lastGameObjectWithCollision.tag.Equals("Porta")))
        {
            enter.GetComponent<SpriteRenderer>().enabled = true;
        }
        }
        else {
            enter.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.esc();

        }

       
    }

    public void CanInteract(bool status)
    {
        _canInteract = status;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Computador") || collision.gameObject.tag.Equals("NPC") || collision.gameObject.tag.Equals("Porta"))
        lastGameObjectWithCollision = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        lastGameObjectWithCollision = null;
    }

    public void updateTags(string novaTag) {
        if (flagMissoesConcluidas.Contains(novaTag)==false) {
            flagMissoesConcluidas.Add(novaTag);
        }


    }


}
