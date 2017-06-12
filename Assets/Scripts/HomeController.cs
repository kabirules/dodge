using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}