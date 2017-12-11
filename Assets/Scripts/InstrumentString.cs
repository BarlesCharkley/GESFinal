using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InstrumentString : MonoBehaviour
{

    [SerializeField]
    public int stringNumber;

    private Strum strumScript;

    private ShakeObject shaker;

    private AudioSource thisSpeaker;

    private void Start()
    {
        strumScript = FindObjectOfType<Strum>();
        shaker = GetComponentInChildren<ShakeObject>();
        thisSpeaker = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick")
        {
            StringStrummed();
        }
    }

    public void StringStrummed()
    {
        strumScript.StrumString(stringNumber, thisSpeaker);
        shaker.ShakeNow();
    }

}