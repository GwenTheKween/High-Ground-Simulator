using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeChange : MonoBehaviour {
    public GameObject background;
    public bool menu;

    private Slider sl;
    private AudioSource background_AS;
    void Start()
    {
        sl = GetComponent<Slider>();
        background_AS = background.GetComponent<AudioSource>();
        background_AS.volume = sl.value;
    }
	public void changeVolume(bool which)
    {
        if (which) //changing sfx
        {
            VolumeScript.sfx = sl.value;
        }
        else
        {
            background_AS.volume = sl.value;
            VolumeScript.bgm = sl.value;
        }
    }
}
