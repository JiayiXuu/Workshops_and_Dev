using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    public Material[] materials;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.name!= "Main Camera")
        {
            return;
        }

        //outside
        if (transform.position.z > collider.transform.position.z)
        {
            foreach (var mat in materials)
            {
                mat.SetInt("stest", (int)CompareFunction.Equal);
            }
        } else
        {
            foreach (var mat in materials)
            {
                mat.SetInt("stest", (int)CompareFunction.NotEqual);
            }
        }
    }
}
