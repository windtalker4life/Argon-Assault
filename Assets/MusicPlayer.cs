using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        int Musicplayer = FindObjectsOfType<MusicPlayer>().Length;
        if (Musicplayer > 1)
        {
            Destroy(gameObject);
            print(Musicplayer);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
