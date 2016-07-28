using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour
{
    public GameObject selfExplosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }

        else if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Drop"))
            return;

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        if(selfExplosion != null)
        {
            Instantiate(selfExplosion, transform.position, transform.rotation);
        }
        
        if(other.CompareTag("Bolt"))
        {
            gameController.AddScore(scoreValue);
        }

        Destroy (other.gameObject);
        Destroy(gameObject);
    }

}
