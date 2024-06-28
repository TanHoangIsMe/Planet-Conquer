using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerController : MonoBehaviour
{
    private void Awake()
    {
        int numberOfMusicPlayer = FindObjectsByType<MusicPlayerController>
            (FindObjectsSortMode.None).Length;
        if (numberOfMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
