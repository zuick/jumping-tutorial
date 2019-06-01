using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{
	public bool Grounded = false;
	public float GroundCheckRadious = 0.1f;
	public LayerMask GroundLayer;

	protected virtual void FixedUpdate()
	{
		Grounded = Physics2D.OverlapCircle(transform.position, GroundCheckRadious, GroundLayer);
	}
}
