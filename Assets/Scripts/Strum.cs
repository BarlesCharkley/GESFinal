using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strum : MonoBehaviour
{
    [SerializeField]
    public GameObject pick;

    [SerializeField]
    private AudioClip[] sounds;

    [Range(0, 1)]
    [SerializeField]
    private float[] pitchMultipliers;

	void Start ()
    {

	}
	
	void Update ()
    {
		
	}

    public void StrumString(int stringNum, AudioSource speaker)
    {
        int randomSound = Random.Range(1, sounds.Length);
        speaker.pitch = pitchMultipliers[stringNum - 1];
        speaker.PlayOneShot(sounds[randomSound - 1]);
        Debug.Log("String #" + stringNum);
    }

}
