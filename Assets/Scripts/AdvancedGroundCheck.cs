using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AdvancedGroundCheck : GroundCheck
{
	public GroundCheck[] points;

	protected override void FixedUpdate()
	{
		Grounded = points.Any(p => p.Grounded);
	}
}