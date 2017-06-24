using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using StartApp;

public class HomeController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        StartAppWrapper.init();
#endif
#if UNITY_ANDROID
        StartAppWrapper.addBanner(
              StartAppWrapper.BannerType.AUTOMATIC,
              StartAppWrapper.BannerPosition.BOTTOM);
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    void OnGUI()
    {
#if UNITY_ANDROID
        StartAppWrapper.showSplash();
#endif
    }
}