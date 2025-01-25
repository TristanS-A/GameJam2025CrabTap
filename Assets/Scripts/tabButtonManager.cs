using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tabButtonManager : MonoBehaviour
{
    public List<Button> purchasedDomains;
    [SerializeField] Button websiteTabTemplate;
    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toWebsite()
    {

    }

    //Function to add a new button
    public void addButton()
    {
        Button b = Instantiate(websiteTabTemplate);
        b.transform.SetParent(canvas.transform);
        //b.onClick.AddListener(toWebsite());
    }
}
