using UnityEngine;
using Rewired;

public class Movement : MonoBehaviour
{
	public float Speed;
	public Rigidbody2D Body;

	private Player playerInput;

	private void Awake()
	{
		playerInput = ReInput.players.GetPlayer(0);
	}

	private void Update()
	{
		var moveX = playerInput.GetAxis("MoveHorizontal");

		if (Mathf.Abs(moveX) > 0.1f)
			transform.rotation = Quaternion.Euler(0f, moveX < 0 ? -180f : 0f, 0f);

		Body.velocity = new Vector2(moveX * Speed, Body.velocity.y);

	}
}
