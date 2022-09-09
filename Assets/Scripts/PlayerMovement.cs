using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
		Jump();
    }

	Vector2 Movement()
	{
		if (Input.GetKey(KeyCode.A))
		{
			return rb.velocity = new Vector2(-player.speed, rb.velocity.y);
		}
		else
		{
			if (Input.GetKey(KeyCode.D))
			{
				return rb.velocity = new Vector2(+player.speed, rb.velocity.y);
			}
			else
			{
				return rb.velocity = new Vector2(0, rb.velocity.y);
			}
		}
	}
	public void Jump()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if ((player.isGrounded == true) || ((player.touchingWall == true) && (player.currentSprite == "Isometric Diamond")))
			{
				rb.AddForce(Vector2.up * player.jumpAmount, ForceMode2D.Impulse);
			}
		}
    }
}
