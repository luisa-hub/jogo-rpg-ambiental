
using Cinemachine;
using UnityEngine;

public class SwitchConfineBoundingShape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchBoundingShape();
    }

    /// <summary>
    /// Switch the collider that cinemachine uses to define the edges of the screen
    /// </summary>
    private void SwitchBoundingShape()
    {
        //Get the polygon collider on the "boundconfiner"
        //gameobjetc which is used by CineMachine to prevent the camera going beyond the screnn edges 
        PolygonCollider2D polygonCollider2D = 
            GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).GetComponent<PolygonCollider2D>();


        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();

        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;

        //clear the cache
        cinemachineConfiner.InvalidatePathCache();
    
        
    }
}
