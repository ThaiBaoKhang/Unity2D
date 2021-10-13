using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPrefabs : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform InstantiateMe;


    void Start()
    {
        Instantiate(InstantiateMe, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
