using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{
	public float GroundCheckRadious = 0.1f;
	public LayerMask GroundLayer;
	[HideInInspector]
	public bool Grounded { protected set; get; }

	protected virtual void FixedUpdate()
	{
		Grounded = Physics2D.OverlapCircle(transform.position, GroundCheckRadious, GroundLayer);
	}
}
