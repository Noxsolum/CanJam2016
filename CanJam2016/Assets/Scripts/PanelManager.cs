using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject currentPanel;
    public GameObject[] prefabs;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < 10; i++)
        {
            spawnPanel();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spawnPanel()
    {
        int rand = Random.Range(0, 2);
        currentPanel = (GameObject)Instantiate(tilePrefab, currentPanel.transform.GetChild(0).transform.GetChild(rand).position, Quaternion.identity);
        if (rand == 0)
        {
            int prefabNum = 0; //Random.Range(0, 3);
            Instantiate(prefabs[prefabNum], currentPanel.transform.GetChild(0).transform.GetChild(rand).position, Quaternion.identity);
        }
        else { }

    }
}
