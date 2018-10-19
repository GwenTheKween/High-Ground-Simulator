using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour {

    public float freq;

    private int stage;

	// Use this for initialization
	void Start () {
        stage = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnAudioFilterRead(float[] data, int channel){
        float val;
        int i,j;
        if(stage == 3)
        {
            stage--;
            for (i = 0;i<128; i++)
            {
                val = VolumeScript.sfx * Mathf.Sin(freq * i * i / 128);
                for (j = 0; j < channel; j++) data[channel * i + j] = val;
            }
            for(i = 128; i <data.Length / channel; i++)
            {
                val = VolumeScript.sfx * Mathf.Sin(freq * i);
                for (j = 0; j < channel; j++) data[channel * i + j] = val;
            }
        }
        else if (stage == 2)
        {
            float tmp =  channel / ( 2 * data.Length);
            for (i = 0; i < data.Length / channel; i++)
            {
                val = VolumeScript.sfx * Mathf.Sin(freq*i*(1-tmp*i));
                for(j = 0; j<channel; j++)
                {
                    data[channel * i + j] = val;
                }
            }
            stage--;
        }
        else if (stage == 1)
        {
            float tmp =  channel / ( 2 * data.Length);
            for (i = 0; i < data.Length / channel; i++)
            {
                val = VolumeScript.sfx * Mathf.Sin(freq * i * (0.5f - tmp*i));
                for (j = 0; j < channel; j++)
                {
                    data[channel * i + j] = val;
                }
            }
            stage--;
        }
    }

    public void play()
    {
        stage = 3;
        while (stage > 0) ;
    }
}
