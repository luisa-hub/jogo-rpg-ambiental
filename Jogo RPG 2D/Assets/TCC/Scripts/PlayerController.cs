﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _canInteract = true;
    private GameObject lastGameObjectWithCollision;
    public List<string> flagMissoesConcluidas;

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
                NPCController nPCController = lastGameObjectWithCollision.GetComponent<NPCController>();
                nPCController.InitInteraction(flagMissoesConcluidas);
            }
        }
    }

    public void CanInteract(bool status)
    {
        _canInteract = status;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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