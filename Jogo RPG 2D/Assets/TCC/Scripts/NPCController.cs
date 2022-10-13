using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    private ChatController chatController;
    public List<string> textos;
    public Sprite retrato;

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
       
        chatController.IniciaDialogo(textos, flagMissoesConcluidas, retrato);
   
        
    }

    


}
