﻿using UnityEngine;
using System.Collections;

public class VisualizerBasic: MonoBehaviour {

	protected GameObject[] visualizerObjects;
	private int numberOfObjects;

    //scale to reset to after each rescale
	//public float defaultScaleX = 1;
	//public float defaultScaleY = 1;
	//public float defaultScaleZ = 1;

    [SerializeField]
    public Vector3 defaultScale;

    //visualizer growth amount
	//public float CrankItX = 0;
	//public float CrankItY = 10;
	//public float CrankItZ = 0;

    [SerializeField]
    public Vector3 visIntensity;


    void Start() 
	{
		visualizerObjects = GameObject.FindGameObjectsWithTag ("Visualizer");
		numberOfObjects = visualizerObjects.Length;
	}
	
	// Update is called once per frame
	void Update ()
	{
        Visualize1();	
	}

    void Visualize1()
    //standard visualizer system
    {
        float[] spectrum1 = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 previousScale = visualizerObjects[i].transform.localScale;
            previousScale.x = (spectrum1[i] * visIntensity.x) + defaultScale.x; //additive, non-continuous x growth
            previousScale.y = (spectrum1[i] * visIntensity.y) + defaultScale.y; //additive, non-continuous y growth
            previousScale.z = (spectrum1[i] * visIntensity.z) + defaultScale.z; //additive, non-continuous z growth
            visualizerObjects[i].transform.localScale = previousScale;

            //display number of objects in visualizer set:
            //Debug.Log (visualizerObjects.Length + " Objects");
        }
    }

    //void Visualize2()
    ////constant growth system, tree-style
    //{
    //    float[] spectrum1 = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
    //    for (int i = 0; i < numberOfObjects; i++)
    //    {
    //        Vector3 previousScale = visualizerObjects[i].transform.localScale;
    //        previousScale.x += (spectrum1[i] * CrankItX); //additive, continuous x growth
    //        previousScale.y += (spectrum1[i] * CrankItY); //additive, continuous y growth
    //        previousScale.z += (spectrum1[i] * CrankItZ); //additive, continuous z growth
    //        visualizerObjects[i].transform.localScale = previousScale;

    //        //display number of objects in visualizer set:
    //        //Debug.Log (visualizerObjects.Length + " Objects");
    //    }
    //}

}


