using UnityEngine;
using System.Collections;

public class CueBall : MonoBehaviour
{
    private Vector3 m_position;
    private Rigidbody2D m_rigidbody;
    private Vector3 m_force;

    // Use this for initialization
    void Start()
    {

        //m_position = new Vector3(5, 0, 0);
        m_rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseDist = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //selected = false;
        if (Input.GetMouseButton(0))
        {

            m_force = m_rigidbody.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            m_force.z = 0;
            Ray a = new Ray(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.DrawLine(a.origin, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        }
        else
        if (Input.GetMouseButtonUp(0))
        {
            m_rigidbody.AddForce(m_force * mouseDist.magnitude * 50 * Time.deltaTime, ForceMode2D.Impulse);

        }
        m_rigidbody.velocity *= 0.995f;//friction decay
    }
}
