using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWave : MonoBehaviour {

    public AudioSource aud;
    public Shader waveShader;

    public string tagToSearch;//the tag to search for objects
    private GameObject[] toWave;//objects that will wave

    [SerializeField]
    private float[] spectrum;
    private int channels = 2;//the number of channels. 8^channels

    public float waveSpeed = .8f;//how fast the wave moves
    private float oldWaveSpeed;//caching the old speed

    public float waveDistance = .1f;//how far from the middle of the object the vertexes move
    public float waveFrequency = .1f;//how many waves go through the object


    private float musicMod = 30f;//how much the audio is multiplied

    //the range that the speed gets its average from the audio spectrum
    public int minIndex = 0;//first
    public int maxIndex = 10;

    private float avg;//average between the spectrums
    GameObject player;

    public bool enablePulsing = false;
    public bool enableSwaying = false;

    bool pulse = false;
    int pulse2 = 0;
    float smoothVal = 0;

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
	void FixedUpdate ()
    {
        ////get the audio data
        aud.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

        ////waveSpeed = Mathf.Lerp(waveSpeed, spectrum[5] * musicMod, Time.deltaTime);

        //float tempHolder = 0;
        //float tempToDivide = 0;

        ////get average between the index
        //for (int i = minIndex; i < maxIndex; ++i)
        //{
        //    tempHolder += spectrum[i];
        //    ++tempToDivide;
        //}

        //avg = (tempHolder / tempToDivide) * musicMod;

        //if (avg > 1)
        //{
        //    waveSpeed = Mathf.SmoothStep(waveSpeed, 2, Time.deltaTime * .5f);
        //}

        //else
        //{
        //    waveSpeed = Mathf.Lerp(waveSpeed, 1, Time.deltaTime);
        //}

        //waveSpeed += Mathf.Lerp(waveSpeed, avg, Time.deltaTime * 4);

        //waveSpeed = Mathf.Clamp(waveSpeed, 1, 3);



        //oldWaveSpeed = waveSpeed;

        if (spectrum[4] > 0.01 && !pulse && enablePulsing)
        {
            pulse = true;
            pulse2 = 1;
            smoothVal = 0;
        }
        if (pulse)
        {
            smoothVal += Time.deltaTime * 20.0f;
            if (smoothVal > 5.0f)
            {
                pulse = false;
                pulse2 = 0;
                smoothVal = 0;
            }
        }
        foreach (GameObject g in toWave)//for every waving object
        {
            if (!g.GetComponent<EnvironmentInteractScript>().isActive)
            {
                MeshRenderer mesh = g.GetComponent<MeshRenderer>();//grab the mesh

                Vector4 pos = player.transform.position;

                for (int index = 0; index < mesh.materials.Length; ++index)
                {
                    if (mesh.materials[index].shader.name != waveShader.name)
                    {
                        mesh.materials[index].shader = waveShader;//change the shader if need be
                    }

                    //send the data
                    mesh.materials[index].SetFloat("_Music", smoothVal);
                    mesh.materials[index].SetInt("_Pulse", pulse2);
                    mesh.materials[index].SetFloat("_Speed", waveSpeed);
                    mesh.materials[index].SetFloat("_Distance", waveDistance);
                    mesh.materials[index].SetVector("_Dist", pos);
                    mesh.materials[index].SetFloat("_Frequency", waveFrequency);
                }
            }

        }
    }
}
