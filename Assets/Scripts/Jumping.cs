using UnityEngine;

public class Jumping : MonoBehaviour
{
	public float Force;
	public Rigidbody2D Body;
	public GroundCheck GroundCheck;

	private bool isJumpPressed;

	private void Update()
	{
		isJumpPressed = Input.GetButton("Jump");
		if (Input.GetButtonDown("Jump") && GroundCheck.Grounded)
			Body.AddForce(new Vector2(0f, Force), ForceMode2D.Impulse);
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