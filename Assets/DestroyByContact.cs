using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject playerExplosion;
    private GameController gameController;

    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Wall")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
            Debug.Log("Player has been hit");
        }
        Destroy(gameObject);
    }
}
