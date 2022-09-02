using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    private GameObject chatCanvas;
    public string text;

    // Start is called before the first frame update
    void Start()
    {
        chatCanvas = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitInteraction()
    {
        chatCanvas.GetComponentInChildren<ChatController>().SetVisible(true);
        // Bloqueia o input do teclado para o personagem
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(false);
    }


}
