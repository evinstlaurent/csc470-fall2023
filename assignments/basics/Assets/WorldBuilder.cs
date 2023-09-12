using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject gasCanPrefab;
    public GameObject playerPrefab;
    public GameObject pathPrefab;
    public GameObject grassPrefab;

    // Start is called before the first frame update
    void Start()
    {
        generateTrees();
        generateGasCans();
        generatePlayer();
        generatePath();
    }

    // Function to generate trees
    void generateTrees()
    {
        for (int i = 0; i <= 100; i++)
        {
            Vector3 position = new Vector3(Random.Range(-140, -60), 0, Random.Range(-240,240));
            GameObject tree = Instantiate(treePrefab, position, Quaternion.identity);
            tree.transform.Rotate(0, Random.Range(0,359), 0);
        }

        for (int i = 0; i <= 100; i++)
        {
            Vector3 position = new Vector3(Random.Range(60, 140), 0, Random.Range(-240,240));
            GameObject tree = Instantiate(treePrefab, position, Quaternion.identity);
            tree.transform.Rotate(0, Random.Range(0,359), 0);
        }

        for (int i = 0; i <= 30; i++)
        {
            Vector3 position = new Vector3(Random.Range(-140, 140), 0, Random.Range(210,240));
            GameObject tree = Instantiate(treePrefab, position, Quaternion.identity);
            tree.transform.Rotate(0, Random.Range(0,359), 0);
        }
    }

    // Function to generate gas cans
    void generateGasCans()
    {
        float yPosition = 0;
        for(int z = -225; z >= -245; z -= 10){
            for(int x = -20; x <= 20; x += 5)
            {
                Vector3 position = new Vector3(x, yPosition, z);
                GameObject gasCan = Instantiate(gasCanPrefab, position, Quaternion.identity);
                gasCan.transform.Rotate(0, 30, 0);
            }
        }
    }

    // Function to generate player
    void generatePlayer()
    {
        float xPosition = 0;
        float yPosition = 0;
        float zPosition = -200;
        Vector3 position = new Vector3(xPosition, yPosition, zPosition);
        GameObject player = Instantiate(playerPrefab, position, Quaternion.identity);
    }

    // Function to generate path
    void generatePath()
    {
        float yPosition = 0;
        for (int x = -28; x <= 28; x += 56)
        {
            for (int z = -210; z <= 165; z += 75)
            {
                Vector3 position = new Vector3(x, yPosition, z);
                GameObject path = Instantiate(pathPrefab, position, Quaternion.identity);
            }
        }
    }

    // Unused function to generate grass (slowed game way down too much)
    void generateGrass()
    {
         for (int i = 0; i <= 10; i++)
        {
            Vector3 position = new Vector3(Random.Range(-140, -60), 0, Random.Range(-240,240));
            GameObject grass = Instantiate(grassPrefab, position, Quaternion.identity);
            grass.transform.Rotate(0, Random.Range(0,359), 0);
        }

        for (int i = 0; i <= 10; i++)
        {
            Vector3 position = new Vector3(Random.Range(60, 140), 0, Random.Range(-240,240));
            GameObject grass = Instantiate(grassPrefab, position, Quaternion.identity);
            grass.transform.Rotate(0, Random.Range(0,359), 0);
        }

        for (int i = 0; i <= 10; i++)
        {
            Vector3 position = new Vector3(Random.Range(-140, 140), 0, Random.Range(210,240));
            GameObject grass = Instantiate(grassPrefab, position, Quaternion.identity);
            grass.transform.Rotate(0, Random.Range(0,359), 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
