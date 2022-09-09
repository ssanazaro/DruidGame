using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite circle;
    public Sprite square;
    public Sprite diamond;
    public bool isGrounded;
    public bool touchingWall;
    public string currentSprite;
    public float speed = 15f;
    public float jumpAmount = 5f;

    // Start is called before the first frame update
    void Start()
    {
        currentSprite = currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        speed = 15f;
        jumpAmount = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = circle;
            currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            speed = 15f;
            jumpAmount = 5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
		{
            gameObject.GetComponent<SpriteRenderer>().sprite = square;
            currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            speed = 5f;
            jumpAmount = 5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = diamond;
            currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            speed = 10f;
            jumpAmount = 10f;
            Debug.Log(currentSprite);
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("Ground"))
		{
            isGrounded = true;
		}
        if (collision.gameObject.tag.Equals("Enemy") && (currentSprite != "Square"))
        {
            DestroyPlayer();
        }
        if (collision.gameObject.tag.Equals("MovingWall"))
        {
            DestroyPlayer();
        }
        if (collision.gameObject.tag.Equals("Wall"))
        {
            touchingWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.tag.Equals("Wall"))
        {
            touchingWall = false;
        }
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().LoseGame();
    }
}
