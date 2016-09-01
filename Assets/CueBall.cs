using UnityEngine;
using System.Collections;

public class CueBall : MonoBehaviour
{
    private Vector3 m_position;
    private Rigidbody2D m_rigidBody;
    private Vector3 m_force;
    private Vector3[] m_vertices = new Vector3[2];
    private LineRenderer m_lineRenderer;

    // Use this for initialization
    void Start()
    {

        //m_position = new Vector3(5, 0, 0);
        m_rigidBody = this.GetComponent<Rigidbody2D>();
        m_lineRenderer = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseDist = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //selected = false;
        if (Input.GetMouseButton(0))
        {

            m_force = m_rigidBody.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            m_force.z = 0;
            Ray a = new Ray(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.DrawLine(a.origin, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            m_vertices[0] = transform.position;
            m_vertices[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        if (Input.GetMouseButtonUp(0))
        {
            m_rigidBody.AddForce(m_force * mouseDist.magnitude * 50 * Time.deltaTime, ForceMode2D.Impulse);
            m_vertices[0] = Vector3.zero;
            m_vertices[1] = Vector3.zero;
        }
        m_vertices[0].z = 0;
        m_vertices[1].z = 0;
        m_lineRenderer.SetPositions(m_vertices);

        m_rigidBody.velocity *= 0.995f;//friction decay
    }
}
