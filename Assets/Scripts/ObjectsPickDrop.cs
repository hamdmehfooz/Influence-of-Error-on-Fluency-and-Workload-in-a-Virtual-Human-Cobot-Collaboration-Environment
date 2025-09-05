using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectsPickDrop : MonoBehaviour
{
    public GameObject robotic_arm_end;
    public GameObject ring;
    public GameObject bolt;
    public GameObject criclip;
    public GameObject bearing;

    public Vector3 ringOffset;
    public Vector3 bearingOffset;
    public Vector3 criclipOffset;
    public Vector3 boltOffset;
    public void Pickupring()
    {
        ring.SetActive(true);
        ring.transform.SetParent(robotic_arm_end.transform);
        ring.transform.localPosition = ringOffset;
    }

    public void DropRing()
    {
        ring.SetActive(false);
    }

    public void Pickupbearing()
    {
        bearing.SetActive(true);
        bearing.transform.SetParent(robotic_arm_end.transform);
        bearing.transform.localPosition = bearingOffset;
    }
    public void DropBearing()
    {
        bearing.SetActive(false);
    }

    public void Pickupcriclip()
    {
        criclip.SetActive(true);
        criclip.transform.SetParent(robotic_arm_end.transform);
        criclip.transform.localPosition = criclipOffset;
    }
    public void DropCriclip()
    {
        criclip.SetActive(false);
    }
    public void Pickupbolt()
    {
        bolt.SetActive(true);
        bolt.transform.SetParent(robotic_arm_end.transform);
        bolt.transform.localPosition = boltOffset;
    }
    public void DropBolt()
    {
        bolt.SetActive(false);
    }
}
