using UnityEngine;
using System.Collections;

public class NormalBall : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private AudioSource m_audioSource;
    // Use this for initialization
    void Start()
    {
        m_audioSource = this.GetComponent<AudioSource>();
        m_rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame


    void OnCollisionEnter2D(Collision2D a_col)
    {
        if(a_col.collider.CompareTag("Ball"))
        {
            m_audioSource.Play();
        }
    }



    void Update()
    {
        
        m_rigidbody.velocity *= 0.98f;
    }
}
