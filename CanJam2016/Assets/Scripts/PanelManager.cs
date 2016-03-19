using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject currentPanel;

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
        currentPanel = (GameObject)Instantiate(tilePrefab, currentPanel.transform.GetChild(0).transform.GetChild(Random.Range(0, 2)).position, Quaternion.identity);

    }
}
