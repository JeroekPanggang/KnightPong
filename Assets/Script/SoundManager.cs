using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagers : MonoBehaviour
{
    private bool isMuted = false;

    public void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
    }
}
