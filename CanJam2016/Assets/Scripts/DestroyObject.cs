using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour
{
    public int numOfObjects;

	// Use this for initialization
	void Start ()
    {
        numOfObjects = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
        numOfObjects--;
    }
}
