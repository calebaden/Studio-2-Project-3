using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWave : MonoBehaviour {

    public AudioSource aud;
    public Shader waveShader;

    public string tagToSearch;//the tag to search for objects
    private GameObject[] toWave;//objects that will wave

    private float[] spectrum;
    public int channels = 2;//the number of channels. 8^channels

    public float waveSpeed = .8f;//how fast the wave moves
    private float oldWaveSpeed;//caching the old speed

    public float waveDistance = .1f;//how far from the middle of the object the vertexes move
    public float waveFrequency = .1f;//how many waves go through the object

    public float musicMod = 30f;//how much the audio is multiplied

    //the range that the speed gets its average from the audio spectrum
    public int minIndex = 0;//first
    public int maxIndex = 10;
    private float avg;//average between the spectrums

    private float dist;
    public float offset;
    GameObject player;

    // Use this for initialization
    void Start ()
    {
        Mathf.Clamp(channels, 2, 4);//8^5 causes NaNs
        spectrum = new float[(int)Mathf.Pow(8, channels)];

        if (maxIndex > spectrum.Length)
            maxIndex = spectrum.Length;

        toWave = GameObject.FindGameObjectsWithTag(tagToSearch);
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        //get the audio data
        aud.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

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

        oldWaveSpeed = waveSpeed;

        waveSpeed = 2;
        //waveSpeed = Mathf.Lerp(waveSpeed, avg, Time.deltaTime * 4f);

        //waveSpeed = (waveSpeed + oldWaveSpeed) * .5f;//then average between the old speed

        foreach (GameObject g in toWave)//for every waving object
        {
            MeshRenderer mesh = g.GetComponent<MeshRenderer>();//grab the mesh

            dist = Vector3.Magnitude(player.transform.position - g.transform.position);

            for (int index = 0; index < mesh.materials.Length; ++index)
            {
                if (mesh.materials[index].shader.name != waveShader.name)
                {
                    mesh.materials[index].shader = waveShader;//change the shader if need be
                }

                //send the data
                //m.SetFloat("_Music", spectrum[5]);
                mesh.materials[index].SetFloat("_Speed", waveSpeed);
                mesh.materials[index].SetFloat("_Distance", waveDistance);
                mesh.materials[index].SetFloat("_Offset", offset);
                mesh.materials[index].SetFloat("_Dist", dist);
                mesh.materials[index].SetFloat("_Frequency", waveFrequency);            
            }
        }
    }
}
