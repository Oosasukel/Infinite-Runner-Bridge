using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;

    private bool instantiated;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();

        rb.velocity = new Vector2(gameManager.objectsSpeed, 0);
    }

    void Update()
    {
        if (!instantiated && transform.position.x <= 0)
        {
            instantiated = true;

            Vector2 newBridgePosition = transform.position + new Vector3(gameManager.bridgeWidth, 0);
            Instantiate(gameManager.bridgePrefab, newBridgePosition, gameManager.bridgePrefab.transform.rotation);
        }

        if (transform.position.x < gameManager.positionXToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
