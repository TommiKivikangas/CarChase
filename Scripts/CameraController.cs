using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public static CameraController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        // sets the cameras position
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // changes the cameras position as the player moves
        transform.position = player.transform.position + offset;
    }
}
