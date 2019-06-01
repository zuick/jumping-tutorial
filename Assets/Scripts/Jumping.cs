using UnityEngine;

public class Jumping : MonoBehaviour
{
	public float Force;
	public Rigidbody2D Body;

	private void Update()
	{
		var jump = Input.GetButtonDown("Jump");
		if (jump)
			Body.AddForce(new Vector2(0f, Force), ForceMode2D.Impulse);
	}
}