using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilController : MonoBehaviour
{
    private PlayerController playerController;
    private GameManager gameManager;
    private Rigidbody2D rb;
    private bool reached;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerController = FindObjectOfType<PlayerController>();

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(gameManager.objectsSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < gameManager.positionXToDestroy)
        {
            Destroy(gameObject);
        }

        if (!reached && transform.position.x < playerController.transform.position.x)
        {
            reached = true;
            gameManager.GivePoints(1);
        }
    }
}
