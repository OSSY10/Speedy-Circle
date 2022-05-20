using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSquare : MonoBehaviour
{
    [SerializeField] float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotation * Time.deltaTime);
    }
}
