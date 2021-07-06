using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target;
	public bool follow;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void start()
	{
		follow = false;

	}

	void FixedUpdate()
	{
		if (follow == true)
		{
			Vector3 desiredPosition = target.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;

			transform.LookAt(target);
		}

	}

	public void setFollow(bool follow)
	{
		this.follow = follow;
	}

}