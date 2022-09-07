using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    private ChatController chatController;
    public List<string> textos;

    // Start is called before the first frame update
    void Start()
    {
        chatController = GameObject.Find("Canvas").transform.GetChild(0).gameObject.GetComponentInChildren<ChatController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitInteraction(List<string> flagMissoesConcluidas)
    {
        // Habilito o chat
        chatController.SetVisible(true);
        // Configuro o chat com o texto inicial
        // TODO verificar as variáveis de progresso antes de inicial um chat
        chatController.ConfigureText(textos[0]);
        // Bloqueia o input do teclado para o personagem
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(false);
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(false);
    }


}
