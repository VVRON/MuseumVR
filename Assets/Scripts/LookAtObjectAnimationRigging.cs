using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class LookAtObjectAnimationRigging : MonoBehaviour
{
    private Rig rig;
    private float targetWeight;
    private void Awake()
    {
        rig = GetComponent<Rig>();
    }

    private void Update()
    {
        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime * 10f);

        if (Input.GetKey(KeyCode.T))
        {
            targetWeight = 1f;
        }

        if (Input.GetKey(KeyCode.Y))
        {
            targetWeight = 0f;
        }
    }
}
