using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class DistanceCamera : MonoBehaviour
{
    CinemachineVirtualCamera m_Camera;

    CinemachineComponentBase componentBase;
    CinemachineFramingTransposer transposer;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = GetComponent<CinemachineVirtualCamera>();
        componentBase = m_Camera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        transposer = m_Camera.GetCinemachineComponent<CinemachineFramingTransposer>();
        transposer.m_MaximumDistance = 7;
        transposer.m_MaximumDistance = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {


        if (distance < 7 && Input.mouseScrollDelta.y > 0)
        {
            distance += Input.mouseScrollDelta.y * 0.75f;
            transposer.m_CameraDistance = distance;
        }
        if (distance > 2.5 && Input.mouseScrollDelta.y < 0)
        {
            distance += Input.mouseScrollDelta.y * 0.75f;
            transposer.m_CameraDistance = distance;
        }
    }
}
