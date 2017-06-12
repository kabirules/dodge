using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    public GUIText scoreText;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
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

    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if (!gameController.IsGameOver())
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
            scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }
    }
}