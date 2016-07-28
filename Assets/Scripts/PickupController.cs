using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour
{
    private Collider player;
    private float shieldTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Drop"))
            return;

        if(other.CompareTag("Player") || other.CompareTag("Bolt"))
        {
            if(gameObject.CompareTag("Shield"))
            {
                StartCoroutine(ToggleShield());
            }
        }

        Destroy(gameObject);
    }

    public IEnumerator ToggleShield()
    {
        if (player.enabled)
        {
            player.enabled = false;
            Debug.Log("Player collider OFF");
        }

        else if (!player.enabled)
        {
            player.enabled = true;
            Debug.Log("Player collider ON");
        }

        yield return new WaitForSeconds(shieldTime);
    }
}
