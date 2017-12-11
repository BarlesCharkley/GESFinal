using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AnimControl : MonoBehaviour
{
    #region Editor Fields

    //[SerializeField]
    //private TimelineAsset timeline1;

    [SerializeField]
    private Animator anim1;

    [SerializeField]
    public float inputMin;

    [SerializeField]
    public float inputMax;

    [SerializeField]
    public float inputMult = 1;

    [SerializeField]
    [Range(0, 0.99f)]
    private float playbackTime;

    [SerializeField]
    private float playbackOffset;

    #endregion

    private float horizontalInput;

    private GameObject playerObject;


    void Start ()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        AnimInput();
	}

    private void FixedUpdate()
    {
        AnimScroll();
        UpdateAnimTime();
    }

    void AnimInput()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //horizontalInput = Input.mousePosition.x / Screen.width;
        horizontalInput = (playerObject.transform.rotation.y * inputMult);
    }

    void AnimScroll()
    {
        //if (horizontalInput > inputMin && horizontalInput < inputMax)
        //{
        //    playbackTime = horizontalInput;
        //}

        playbackTime = (horizontalInput + playbackOffset);

    }

    void UpdateAnimTime()
    {
        anim1.ForceStateNormalizedTime(playbackTime);

        //anim1.Play("Leap", 1, playbackTime);
    }
}
