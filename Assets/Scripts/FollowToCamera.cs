using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToCamera : MonoBehaviour
{
    [SerializeField] GameObject thingtofollow;
    private void Update()
    {
        transform.position = thingtofollow.transform.position + new Vector3(0,0,-10);
    }
}
