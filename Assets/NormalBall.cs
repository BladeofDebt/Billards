using UnityEngine;
using System.Collections;

public class NormalBall : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    // Use this for initialization
    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.velocity *= 0.98f;
    }
}
