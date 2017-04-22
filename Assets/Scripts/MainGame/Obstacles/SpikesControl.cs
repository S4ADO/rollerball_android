using UnityEngine;

public class SpikesControl : Obstacle
{
	public GameObject[] spikes;
	private float delay, curTime;
	private bool isUp;

	void Start()
	{
		delay = 3.0f;
		curTime = Time.time;
		isUp = true;
	}

	void Update()
	{
		base.Update();
		if (Time.time > curTime + delay)
		{
			foreach (GameObject spike in spikes)
			{
				if (isUp)
				{
					spike.transform.Translate(new Vector3(0, -2, 0));
				}
				else
				{
					spike.transform.Translate(new Vector3(0, 2, 0));
				}
			}
			if (isUp)
			{
				isUp = false;
			}
			else
			{
				isUp = true;
			}
			curTime = Time.time;
		}
	}
}
