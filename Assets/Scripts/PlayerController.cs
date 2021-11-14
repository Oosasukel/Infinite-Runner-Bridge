using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        float posY = Mathf.Clamp(transform.position.y, gameManager.yMinLimit, gameManager.yMaxLimit);
        float posX = Mathf.Clamp(transform.position.x, gameManager.xMinLimit, gameManager.xMaxLimit);

        rb.velocity = new Vector2(direction.x * gameManager.speed, direction.y * gameManager.speed);

        transform.position = new Vector3(posX, posY, 0);
    }

    void OnTriggerEnter2D()
    {
        Debug.LogError("GameOver");
    }
}
