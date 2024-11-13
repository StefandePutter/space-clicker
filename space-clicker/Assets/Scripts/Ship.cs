using System.Collections;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speedX;
    
    [SerializeField] private float resetXPosition;
    
    private float shipWidth;

    private float randomPos;

    private GameManager game;

    [SerializeField] int scoreAmount;
    [SerializeField] int scoreLoss;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();

        shipWidth = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speedX * Time.deltaTime, 0f, 0f);
        if (transform.position.x + (shipWidth / 2f) < 0)
        {
            game.AddScore(scoreLoss);
            // terug plaatsen van het schip
            transform.position = new Vector3(resetXPosition, transform.position.y, transform.position.z);
        }
    }

    private void OnMouseDown()
    {
        randomPos = Random.Range(-4.3f, 4.3f);

        transform.position = new Vector3(resetXPosition, randomPos, transform.position.z);

        game.AddScore(scoreAmount);
    }
}
