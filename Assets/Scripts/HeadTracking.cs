using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HeadTracking : MonoBehaviour
{
    public Transform Target;
    public Rig HeadRig;
    public float Radius = 10f;
    public float RetargetSpeed = 5f;
    public float MaxAngle = 90f;

    List<PointOfInterest> POIs;
    float RadiusSqr;
    void Start()
    {
        POIs = FindObjectsOfType<PointOfInterest>().ToList();
        RadiusSqr = Radius * Radius;
    }

    void Update()
    {
        Transform tracking = null;
        foreach (PointOfInterest poi in POIs)
        {
            Vector3 delta = poi.transform.position - transform.position;
            if (delta.sqrMagnitude < RadiusSqr)
            {
                float angle = Vector3.Angle(transform.forward, delta);
                if (angle < MaxAngle) 
                {
                    tracking = poi.transform;
                    break;
                }
                
            }
        }

        float rigWeight = 0;
        Vector3 targetPos = transform.position + (transform.forward * 2f);
        if (tracking != null)
        {
            targetPos = tracking.position;
            rigWeight = 1;
        }
        Target.position = Vector3.Lerp(Target.position, targetPos, Time.deltaTime * RetargetSpeed);
        HeadRig.weight = Mathf.Lerp(HeadRig.weight, rigWeight, Time.deltaTime * 2);
    }
}
