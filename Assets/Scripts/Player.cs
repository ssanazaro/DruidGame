using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite normalForm;
    public Sprite strongForm;
    public Sprite jumpForm;
    public Sprite fastForm;
    public bool isGrounded;
    public bool touchingWall;
    public string currentSprite;
    public float speed = 15f;
    public float jumpAmount = 5f;
    public float jumpCharges;
    private float maxJumpCharges = 1f;
    private float jumpFormMaxJumpCharges = 2f;

    // Start is called before the first frame update
    void Start()
    {
        currentSprite = currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        speed = 7f;
        jumpAmount = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //This represents the human form
            gameObject.GetComponent<SpriteRenderer>().sprite = normalForm;
            currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            speed = 7f;
            jumpAmount = 5f;
            jumpCharges = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
		{
            //This represents the tank form
            gameObject.GetComponent<SpriteRenderer>().sprite = strongForm;
            currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            speed = 5f;
            jumpAmount = 5f;
            jumpCharges = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //This represents the double fast form
            gameObject.GetComponent<SpriteRenderer>().sprite = fastForm;
            currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            speed = 10f;
            jumpAmount = 5f;
            jumpCharges = 1f;
            Debug.Log(currentSprite);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //This represents the double jump form
            gameObject.GetComponent<SpriteRenderer>().sprite = jumpForm;
            currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
            speed = 7f;
            jumpAmount = 5f;
            jumpCharges = 2f;
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("Ground"))
		{
			if (currentSprite == "JumpForm")
			{
                jumpCharges = jumpFormMaxJumpCharges;
            }
			else
			{
                jumpCharges = maxJumpCharges;
            }
        }
		if (collision.gameObject.tag.Equals("Enemy") && (currentSprite != "StrongForm"))
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
		//if (collision.gameObject.tag.Equals("Ground"))
		//{
  //          jumpCharges = jumpCharges - 1f;
		//}
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
