using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleAndSplashSequence : MonoBehaviour
{
    public static int SceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneNumber == 0) {
            StartCoroutine (ToSplashScreen());
        }
        if (SceneNumber == 1) {
            StartCoroutine (ToMainMenu());
        }
    }

    IEnumerator ToSplashScreen() {
        yield return new WaitForSeconds (3);
        SceneNumber = 1;
        SceneManager.LoadScene(1);
    }
    IEnumerator ToMainMenu() {
        yield return new WaitForSeconds (2);
        SceneNumber = 2;
        SceneManager.LoadScene(2);
    }

}
