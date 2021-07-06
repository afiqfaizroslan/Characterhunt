using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnf : MonoBehaviour
{
    public Camera Camera;
    public Transform target;
    public bool follow;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 n_Position;

    void start()
    {
        follow = false;
    }

    public void btnfollow()
    {
        n_Position = new Vector3(target.position.x, 40, target.position.z - 9);
        Camera.transform.position = n_Position;
    }

   
}
