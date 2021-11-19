using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAudio : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
