using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalWallMovement : MonoBehaviour
{
	float timeElapsed;
	float lerpDuration = 1;
	Vector2 downCoordinates;
	Vector2 upCoordinates;
	public float distance = 3;
	public float delay = 0;
	float startTime;

	void Start()
	{
		startTime = Time.time;
		downCoordinates = transform.position;
	}

	void Update()
	{
		//Debug.Log(Time.time);
		//Debug.Log("Start time: " + startTime + delay);
		if (Time.time > startTime + delay)
		{
			if (transform.position.y == downCoordinates.y)
			{
				StartCoroutine(MoveUp());
			}
			else if (transform.position.y == upCoordinates.y)
			{
				StartCoroutine(MoveDown());
			}
		}
	}

	IEnumerator MoveUp()
	{
		timeElapsed = Time.deltaTime;
		while (timeElapsed < lerpDuration)
		{
			transform.position = new Vector2(downCoordinates.x, Mathf.Lerp(downCoordinates.y, downCoordinates.y + distance, timeElapsed / lerpDuration));
			timeElapsed += Time.deltaTime;
			yield return null;
		}
		transform.position = new Vector2(downCoordinates.x, downCoordinates.y + distance);
		upCoordinates = transform.position;
	}

	IEnumerator MoveDown()
	{
		timeElapsed = Time.deltaTime;
		while (timeElapsed < lerpDuration)
		{
			transform.position = new Vector2(upCoordinates.x, Mathf.Lerp(upCoordinates.y, upCoordinates.y - distance, timeElapsed / lerpDuration));
			timeElapsed += Time.deltaTime;
			yield return null;
		}
		transform.position = new Vector2(upCoordinates.x, upCoordinates.y - distance);
		downCoordinates = transform.position;
	}
}
