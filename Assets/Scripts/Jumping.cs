using UnityEngine;

public class Jumping : MonoBehaviour
{
	public float Force;
	public Rigidbody2D Body;
	public GroundCheck GroundCheck;
	public float DelayedJumpDisposeTimeout = 0.2f;

	private bool isJumpPressed;
	private bool delayedJump;

	private void Update()
	{
		isJumpPressed = Input.GetButton("Jump");

		var isJumpDown = Input.GetButtonDown("Jump");
		var isJumpUp = Input.GetButtonDown("Jump");

		if (isJumpDown && !GroundCheck.Grounded)
		{
			delayedJump = true;
			Invoke(nameof(DisposeDelayedJump), DelayedJumpDisposeTimeout);
		}

		if ((isJumpDown || delayedJump) && GroundCheck.Grounded)
		{
			Body.AddForce(new Vector2(0f, Force), ForceMode2D.Impulse);
			delayedJump = false;
		}
	}

	private void DisposeDelayedJump()
	{
		delayedJump = false;
	}

	private void OnDrawGizmos()
	{
		if (isJumpPressed)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(
				Camera.main.ScreenToWorldPoint(Vector3.one * 100f),
				1f
			);
		}
	}
}