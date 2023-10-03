using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOfLifeScript : MonoBehaviour
{
    public GameObject cellPrefab;
    public cellScript[,] cells;
    // Start is called before the first frame update
    void Start()
    {
        // creates cells array
        cells = new cellScript[40,40];

        // creates cell grid and stores in cells array
        for (int x = 0; x < 40; x++)
        {
            for(int y = 0; y < 40; y++)
            {
                Vector3 pos = transform.position;
                pos.x = pos.x + x;
                pos.z = pos.z + y;
                GameObject cellObj = Instantiate(cellPrefab, pos, transform.rotation);


                cells[x, y] = cellObj.GetComponent<cellScript>();
                cells[x, y].x = x;
                cells[x, y].y = y;
                cells[x, y].alive = (Random.value < 0.2f); //sets each cell as randomly alive or dead
            }
        }
        // runs checkPresent function every 0.1 seconds 1 second after the program is began
        InvokeRepeating("checkPresent", 1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // function runs checkNeighbor for each cell and determines if cell should live or die and stores in aliveTemp
    // and then runs updateLiving function after all cells have been checked
    void checkPresent()
    {
        for (int x = 0; x < 40; x++)
        {
            for (int y = 0; y < 40; y++)
            {
                int aliveNum = checkNeighbors(x,y);
                if (aliveNum == 3)
                {
                    cells[x,y].aliveTemp = true;
                }
                else if (aliveNum == 2 && cells[x,y].alive == true)
                {
                    cells[x,y].aliveTemp = true;
                }
                else{
                    cells[x,y].aliveTemp = false;
                }
            }
        }
        updateLiving();
    }

    // updateLiving function sets the aliveTemp value to the actual alive value for each cell which then causes the
    // changes in the cell
    void updateLiving()
    {
        for (int x = 0; x < 40; x++)
        {
            for (int y = 0; y < 40; y++)
            {
            cells[x,y].alive = cells[x,y].aliveTemp;
            }
        }
    }

    // takes x and y as parameters and checks the surrounding neighbors if they are living or not and keeps a count
    // then returns that aliveNum int value
    int checkNeighbors(int x, int y)
    {
        int aliveNum = 0;
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if ((i >= 0) && (j >= 0) && (i < 40) && (j < 40) == true)
                {
                    if (cells[i, j].alive == true)
                    {
                        aliveNum += 1;
                    }
                }
            }
        }
        
        if (cells[x,y].alive)
        {
            return aliveNum - 1;
        }
        else
        {
            return aliveNum;
        }
    }
}