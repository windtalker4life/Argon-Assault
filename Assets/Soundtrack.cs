using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Soundtrack : MonoBehaviour
{
    public static AudioSource audioSource;
    enum Button { PlayGame, Options, Exit, LevelSelect }
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
