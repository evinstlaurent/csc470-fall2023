using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellScript : MonoBehaviour
{
    public bool alive = false;
    public bool onceAlive = false;
    public bool aliveTemp = false;
    public bool trailSwitch = true;
    public Material aliveColor;
    public Material deadColor;
    public Material trailColor;
    public int x = -1;
    public int y = -1;
    Renderer cellRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // gets renderer of the cell and then runs SetState initially to set initial alive and dead cells
        cellRenderer = gameObject.GetComponentInChildren<Renderer>();
        setState();
    }

    // Update is called once per frame
    void Update()
    {
        // if space bar is pressed it toggles the trail on and off
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (trailSwitch == true)
            {
                trailSwitch = false;
            }
            else
            {
                trailSwitch = true;
            }
        }
        // runs setState every frame
        setState();
    }

    // allows user to click on a cell and change its status. if alive, it sets to dead and vice versa.
    void OnMouseDown()
    {
        if (alive == true)
        {
            alive = false;
        }
        else
        {
            alive = true;
        }
    }

    // setState sets the material of the cell at any given time when run to either alive, dead, or trail and also
    // sets the onceAlive condition which determines if trail is used on that cell or not at that time
    void setState()
    {
        if (alive == false)
        {
            if (trailSwitch == true)
            {
                if (onceAlive == true)
                {
                    cellRenderer.material = trailColor;
                }
                else
                {
                    cellRenderer.material = deadColor;
                }
            }
            else
            {
               cellRenderer.material = deadColor; 
            }
        }
        else 
        {
            cellRenderer.material = aliveColor;
            onceAlive = true;
        }

    }
}
