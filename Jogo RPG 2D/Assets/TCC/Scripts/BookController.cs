﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject botaoLivro;
    public GameObject objeto;


    public void abre()
    {

        objeto.SetActive(true);

       Player.Instance.PlayerPauseInteraction();

        botaoLivro.SetActive(false);
    }

    // Update is called once per frame
    public void fecha()
    {
        objeto.SetActive(false);

        Player.Instance.PlayerReturnInteraction();

        botaoLivro.SetActive(true);
    }
}