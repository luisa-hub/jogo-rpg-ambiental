using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    private ChatController chatController;
    public List<string> textos;
    public char stringSeparator = '#';

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

        // verifica as variáveis de progresso antes de inicial um chat

        string textoMandar = textos[0]; //por padrão, caso não tenha nenhuma flag utiliza o primeiro texto por padrão
        for (int i = 0; i < flagMissoesConcluidas.Count; i++) //itera por todos as flags do jogador
        {
            string[] flag = textos[i].Split(stringSeparator); //separa flag do texto
            for (int j =0; j < flag.Length; j++) { 
                if (flag[j]==flagMissoesConcluidas[i]) { //Caso a flag da fala conhicida com uma das flags do jogador, ele seleciona aquela fala pra mandar pro chat
                    textoMandar = textos[i];
                    //caso múltiplas flags do npc presentes no jogador, sempre a última é considerada a certa
                }
            }
        }
   
        // Configuro o chat com o texto
        chatController.ConfigureText(textoMandar);
        // Bloqueia o input do teclado para o personagem
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(false);
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(false);
    }


}
