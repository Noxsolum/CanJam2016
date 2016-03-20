using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour
{
    public GameObject[] tilePrefab;
    public GameObject currentPanel;
    public GameObject[] prefabs;

    public DestroyObject scene;

    private int fenceSpawnDistance;
    private bool leftCornerSpawned, rightCornerSpawned;

	// Use this for initialization
	void Start ()
    {
        fenceSpawnDistance = 0;
        leftCornerSpawned = true;
        rightCornerSpawned = true;

        for (int i = 0; i < 10; i++)
        {
            spawnPanel();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (scene.numOfObjects < 10)
            spawnPanel();
    }

    public void spawnPanel()
    {
        int rand = Random.Range(0, 3);
        int rand2 = Random.Range(0, 10);
        int rand3 = Random.Range(0, 2);
        int index = 0;
        Vector3 position = new Vector3(currentPanel.transform.GetChild(0).transform.GetChild(0).position.x, currentPanel.transform.GetChild(0).transform.GetChild(0).position.y, (currentPanel.transform.GetChild(0).transform.GetChild(0).position.z));
        Vector3 fencePosition = new Vector3((currentPanel.transform.GetChild(0).transform.GetChild(0).position.x), (currentPanel.transform.GetChild(0).transform.GetChild(0).position.y) + 1.5f, (currentPanel.transform.GetChild(0).transform.GetChild(0).position.z) - 7.0f);
        
        if (rand2 == 2 && !leftCornerSpawned && !rightCornerSpawned)
        {
            index = 1;
            leftCornerSpawned = true;
            rightCornerSpawned = true;
        }
        else
        {
            
        }

        if (rand2 == 4 && !rightCornerSpawned && !leftCornerSpawned)
        {
            index = 2;
            rightCornerSpawned = true;
            leftCornerSpawned = true;
        }
        else
        {
            
        }

        if (rand2 == 0 && fenceSpawnDistance < 0 && !rightCornerSpawned && !leftCornerSpawned)
        {
            //Fence
            int prefabNum = 0; //Random.Range(0, 3);
            Instantiate(prefabs[prefabNum], fencePosition, Quaternion.identity);

            scene.numOfObjects++;
            fenceSpawnDistance = 5;

            leftCornerSpawned = false;
            rightCornerSpawned = false;
        }
        else if(rand2 > 5)
        {
            //Pit
            position = new Vector3((currentPanel.transform.GetChild(0).transform.GetChild(0).position.x), (currentPanel.transform.GetChild(0).transform.GetChild(0).position.y), (currentPanel.transform.GetChild(0).transform.GetChild(0).position.z) + 1.5f);

            leftCornerSpawned = false;
            rightCornerSpawned = false;
        }

        fenceSpawnDistance--;
        
        currentPanel = (GameObject)Instantiate(tilePrefab[index], position, Quaternion.identity);
    }
}
