using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyObject : MonoBehaviour
{
    public int numOfObjects;
    [SerializeField] public Text scoreText;
    [SerializeField] public Text gameOver;
    int score;

	// Use this for initialization
	void Start ()
    {
        numOfObjects = 0;
        score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(gameOver.text != "Game Over")
            scoreText.text = "Score: " + score;
	}

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
        numOfObjects--;
        score++;
    }
}
