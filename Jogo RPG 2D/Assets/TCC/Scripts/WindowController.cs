﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class WindowController : MonoBehaviour
{
    public string janela;
    private GameObject objeto;

    // Start is called before the first frame update
    void Start()
    {

        objeto = GameObject.Find(janela).transform.GetChild(0).gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitInteraction()
    {
        objeto.SetActive(true);

        //Para o jogador
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(false);
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(false);
        GameObject.Find("Player").GetComponent<Player>().xInput = 0;
        GameObject.Find("Player").GetComponent<Player>().yInput = 0;
    }

    public void click()
    {
        objeto.SetActive(false);

        //Volta
        GameObject.Find("Player").GetComponent<Player>().PlayerMovementState(true);
        GameObject.Find("Player").GetComponent<PlayerController>().CanInteract(true);
    }

}

