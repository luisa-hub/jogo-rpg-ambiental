using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class AppEvent
{
 
    public static event System.EventHandler OpenBook;

    public static event System.EventHandler CloseBook;

    public static void CloseBookFunction()
    {
        if (CloseBook != null)
            CloseBook(new object(), new EventArgs());

    }

    public static void OpenBookFunction()
    {
        if (OpenBook != null)
            OpenBook(new object(), new EventArgs());
    }

}
