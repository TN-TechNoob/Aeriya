using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CVcamFollow : MonoBehaviour
{
    public CinemachineVirtualCamera bossCam;
    public CinemachineVirtualCamera playerCam;
    public float followBossSecs;

    // Update is called once per frame
    void Update()
    {
        followBossSecs -= Time.deltaTime;
        if (followBossSecs <= 0)
        {
            bossCam.enabled = false;
        }
    }
}
