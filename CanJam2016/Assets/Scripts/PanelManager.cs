using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour
{
    public GameObject tilePrefab;
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
        currentPanel = (GameObject)Instantiate(tilePrefab, currentPanel.transform.GetChild(0).transform.GetChild(rand).position, Quaternion.identity);
        if (rand == 0)
        {
            int prefabNum = 0; //Random.Range(0, 3);
            Vector3 position = new Vector3 (currentPanel.transform.GetChild(0).transform.GetChild(rand).position.x, 1.5f, currentPanel.transform.GetChild(0).transform.GetChild(rand).position.z);

            Instantiate(prefabs[prefabNum], position, Quaternion.identity);

            scene.numOfObjects++;
        }
        else { }

    }
}
