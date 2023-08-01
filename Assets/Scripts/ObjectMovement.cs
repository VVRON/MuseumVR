using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    Vector3 startVector;
    [SerializeField]Vector3 movementVector;



    [SerializeField][Range(0, 1)] float movementFactor;
    void Start()
    {
        startVector = transform.position;
        
    }

    void Update()
    {
        Vector3 offset = movementVector * movementFactor;
        transform.position = startVector + offset;

    }
}
