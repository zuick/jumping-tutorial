using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AccurateGroundCheck : GroundCheck
{
	public GroundCheck topPoint;
	public GroundCheck bottonPoint;

	protected override void FixedUpdate()
	{
		Grounded = !topPoint.Grounded && bottonPoint.Grounded;
	}
}