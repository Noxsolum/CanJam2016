using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour
{
    public GameObject[] tilePrefab;
    public GameObject currentPanel;
    public GameObject[] prefabs;

    public DestroyObject scene;

	// Use this for initialization
	void Start ()
    {
        //scene = new global::DestroyObject();

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
        int rand = Random.Range(0, 2);
        int rand2 = Random.Range(0, 10);
        Vector3 position = new Vector3((currentPanel.transform.GetChild(0).transform.GetChild(rand).position.x) + 0.0f, (currentPanel.transform.GetChild(0).transform.GetChild(rand).position.y), (currentPanel.transform.GetChild(0).transform.GetChild(rand).position.z));;
        Vector3 fencePosition = new Vector3((currentPanel.transform.GetChild(0).transform.GetChild(rand).position.x), (currentPanel.transform.GetChild(0).transform.GetChild(rand).position.y) + 1.5f, (currentPanel.transform.GetChild(0).transform.GetChild(rand).position.z) - 7.0f);
        
        if (rand2 == 0)
        {
            int prefabNum = 0; //Random.Range(0, 3);
            Instantiate(prefabs[prefabNum], fencePosition, Quaternion.identity);

            scene.numOfObjects++;
        }
        else if(rand2 > 5)
        {
            position = new Vector3((currentPanel.transform.GetChild(0).transform.GetChild(rand).position.x) + 0.0f, (currentPanel.transform.GetChild(0).transform.GetChild(rand).position.y), (currentPanel.transform.GetChild(0).transform.GetChild(rand).position.z) + 2.5f);
        }

        currentPanel = (GameObject)Instantiate(tilePrefab[rand], position, Quaternion.identity);
    }
}
