using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
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
    void Start()
    {
        Invoke("Game",2f);
    }

    private void Game()
    {
        SceneManager.LoadScene(1);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
