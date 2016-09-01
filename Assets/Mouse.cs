using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
