using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;

    private Vector3 startPosition;
    private float tileLength;

    void Start ()
    {
        startPosition = transform.position;
        tileLength = transform.localScale.y;
    }

	void Update ()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileLength);
        transform.position = startPosition + Vector3.forward * newPosition;
	}
}
