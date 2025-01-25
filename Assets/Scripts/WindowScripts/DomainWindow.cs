using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomainWindow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (string domainID in DomainStorage.getDomainInfoList().Keys)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
