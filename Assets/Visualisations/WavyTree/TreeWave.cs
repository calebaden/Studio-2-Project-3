using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWave : MonoBehaviour {

    public AudioSource aud;

    public float[] spectrum;
    public int channels = 16;

    public int currIndex = 0;//the currently selected audio spectrum

    public float waveSpeed = .8f;//how fast the wave moves
    public float waveDistance = .1f;//how far from the middle of the object the vertexes move
    public float waveFrequency = .1f;//how many waves go through the object

    public float musicMod = 30f;

    //the range that the speed gets its average from the audio spectrum
    public int minIndex = 0;
    public int maxIndex = 10;
    private float avg;

    private MeshRenderer mesh;

    // Use this for initialization
    void Start ()
    {
        if (Mathf.IsPowerOfTwo(channels))
            spectrum = new float[(int)Mathf.Pow(channels, 2f)];

        else
        {
            Debug.Log("Channels not to  power of two.");
            return;
        }

        if (maxIndex > spectrum.Length)
            maxIndex = spectrum.Length;

        //aud = Camera.main.GetComponent<AudioSource>();
        mesh = GetComponent<MeshRenderer>();
        mesh.transform.up = new Vector3(0, 1, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {

        aud.GetSpectrumData(spectrum, 0, FFTWindow.Triangle);

        //waveSpeed = Mathf.Lerp(waveSpeed, spectrum[5] * musicMod, Time.deltaTime);

        float tempHolder = 0;
        float tempToDivide = 0;

        //get average between the index
        for (int i = minIndex; i < maxIndex; ++i)
        {
            tempHolder += spectrum[i];
            ++tempToDivide;
        }

        avg = (tempHolder / tempToDivide) * musicMod;

        waveSpeed = Mathf.Lerp(waveSpeed, avg, Time.deltaTime * 4f);
        waveSpeed = Mathf.Clamp(waveSpeed, 1, 99);

        for (int index = 0; index < mesh.materials.Length; ++index)
        {
            if (mesh.materials[index].shader.name != "Custom/SinWaveVertext")
                continue;

            //m.SetFloat("_Music", spectrum[5]);
            mesh.materials[index].SetFloat("_Speed", waveSpeed);
            mesh.materials[index].SetFloat("_Distance", waveDistance);
            mesh.materials[index].SetFloat("_Frequency", waveFrequency);
            
        }
    }
}
