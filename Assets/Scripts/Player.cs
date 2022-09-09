using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite circle;
    public Sprite square;
    public bool isGrounded;
    public string currentSprite;
    public float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        currentSprite = currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = circle;
            currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            speed = 15f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
		{
            gameObject.GetComponent<SpriteRenderer>().sprite = square;
            currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            speed = 5f;
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("Ground"))
		{
            isGrounded = true;
		}
        if (collision.gameObject.tag.Equals("Enemy") && (currentSprite == "Circle"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("MovingWall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = false;
        }
    }
}
