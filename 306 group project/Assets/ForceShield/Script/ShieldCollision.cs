using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{

    public float hitTime = 0f;
    Material mat;
    Vector3 origScale = new Vector3();

    void Start()
    {
        if (GetComponent<Renderer>())
        {
            mat = GetComponent<Renderer>().sharedMaterial;
        }
        origScale = transform.localScale;
    }

    void Update()
    {
        Expand();
    }

    private void Expand()
    {
        if (transform.localScale.x < origScale.x * 4)
        {
            transform.localScale += origScale / 100;
        }
        else
        {
            transform.localScale = origScale;
        }
    }

}

