using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenBook : MonoBehaviour
{
    [SerializeField] Button openBtn = null;
    public Vector3 rotationVector;

    private Quaternion startRotation; 

    bool isOpenClicked;
    private DateTime startTime;
    private DateTime endTime;




    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;

        if (openBtn != null)
            openBtn.onClick.AddListener(() => openBtn_Click());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenClicked)
            transform.Rotate(rotationVector * Time.deltaTime);
        endTime = DateTime.Now;

        if ((endTime - startTime).TotalSeconds >= 1)
        {
            isOpenClicked = false;
            Vector3 newRotation = new Vector3(startRotation.x, 100, startRotation.y);
            transform.rotation = Quaternion.Euler(newRotation);
        
        }

        
    }

    public void openBtn_Click()
    {
        isOpenClicked = true;
        startTime = DateTime.Now;

        rotationVector = new Vector3(0, 100, 0);

    }
}
