using UnityEngine;
using System.Collections;

public class ShakeObject : MonoBehaviour
{
    [SerializeField]
    private KeyCode testKey;

    [SerializeField]
    private bool startAutomatically;

    [SerializeField]
	private Transform objectTransform;

    [SerializeField]
    public float shakeDuration = 1f;

    [SerializeField]
	public float shakeAmount = 0.2f;

    [SerializeField]
	private float decreaseFactor = 1.0f;

	private Vector3 originalPos;

    private float defaultShakeTime;

    private bool shouldShake;


    void Awake()
	{
		if (objectTransform == null)
		{
			objectTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = objectTransform.localPosition;
        defaultShakeTime = shakeDuration;
    }

    void Update()
	{
        if (shouldShake == true)
        {
            ShakeItUp();
        }

        if (Input.GetKeyDown(testKey) || startAutomatically == true)
        {
            ShakeNow();
        }
	}

    public void ShakeItUp()
    {
        if (shakeDuration > 0)
        {
            objectTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            objectTransform.localPosition = originalPos;
            shouldShake = false;
        }
    }

    public void ShakeNow()
    {
        shakeDuration = defaultShakeTime;
        shouldShake = true;
    }
}