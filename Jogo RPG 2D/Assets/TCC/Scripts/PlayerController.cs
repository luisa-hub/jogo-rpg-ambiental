using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject lastGameObjectWithCollision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (lastGameObjectWithCollision && lastGameObjectWithCollision.tag.Equals("NPC"))
            {
                NPCController nPCController = lastGameObjectWithCollision.GetComponent<NPCController>();
                nPCController.InitInteraction();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastGameObjectWithCollision = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        lastGameObjectWithCollision = null;
    }
}
