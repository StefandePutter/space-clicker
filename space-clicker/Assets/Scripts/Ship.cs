using System;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speedX;
    
    [SerializeField] private float resetXPosition;
    
    private float shipWidth;

    private GameManager game;

    [SerializeField] int scoreAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = GetComponent<GameManager>();

        shipWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speedX * Time.deltaTime, 0f, 0f);
        if (transform.position.x + (shipWidth / 2f) < 0)
        {
            // terug plaatsen van het schip
            transform.position = new Vector3(resetXPosition, transform.position.y, transform.position.z);
        }
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);

        game.AddScore(scoreAmount);
    }
}
