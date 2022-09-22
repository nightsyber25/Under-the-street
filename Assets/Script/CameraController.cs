using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Update()
    {
        if(player != null)
        transform.position = new Vector3(player.transform.position.x,transform.position.y, transform.position.z);
    }
}
