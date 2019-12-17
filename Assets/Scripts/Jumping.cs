using UnityEngine;
using Rewired;
using System.Collections;

public class Jumping : MonoBehaviour
{
	public float Force;
	public Rigidbody2D Body;
	public GroundCheck GroundCheck;
	public float DelayedJumpDisposeTimeout = 0.2f;
	public float JumpCancelFactor = 0.5f;

	private bool isJumpPressed;
	private bool delayedJump;

	private Player playerInput;

	private void Awake()
	{
		playerInput = ReInput.players.GetPlayer(0);
	}

	IEnumerator Start()
	{
		yield return new WaitForSeconds(3f);
		foreach (var aem in playerInput.controllers.maps.ElementMapsWithAction("Jump", true))
		{
			Debug.Log($"{aem.actionDescriptiveName}: {aem.elementIdentifierName}, {aem.elementType}");
		}
	}

	private void Update()
	{
		isJumpPressed = playerInput.GetButton("Jump");

		var isJumpDown = playerInput.GetButtonDown("Jump");
		var isJumpUp = playerInput.GetButtonUp("Jump");

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

		if (isJumpUp)
			Body.velocity = new Vector2(Body.velocity.x, Body.velocity.y * JumpCancelFactor);
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