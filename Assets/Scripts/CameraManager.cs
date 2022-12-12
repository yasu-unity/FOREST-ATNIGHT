using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    //ëOÇÃèÍèä
    Vector3 prePosition;
    private void Start()
    {
        prePosition = transform.position;
    }
    void Update()
    {
        Vector3 targetPos = player.transform.position;
        if (prePosition.x < targetPos.x)
        {
            transform.position = targetPos;
        }
        prePosition = transform.position;
    }
}
