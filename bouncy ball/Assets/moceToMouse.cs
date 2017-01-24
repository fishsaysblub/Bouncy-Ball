using UnityEngine;
using System.Collections;

public class moceToMouse : MonoBehaviour
{
    public float m_Radius;
    private float m_Owner;
    public float m_Speed = 5.0f;
    public float m_MaxSpeed = 6000;
    public Vector3 m_Normallized;
    public Camera m_Cam;
    private float m_Height;
    private float m_Width;

    
    void Start()
    {
 
    }

    public Vector3 NormallizeVectors(Vector3 one, Vector3 two)
    {
        Vector3 three = one - two;
        float c = Mathf.Sqrt((three.x * three.x) + (three.y * three.y));
        float Normalx = three.x / c;
        float Normaly = three.y / c;
        return new Vector3(Normalx, Normaly, 0);
    }

    void Update()
    {
        GetComponent<Renderer>().material.color = Color.green;

        m_Height = Camera.main.orthographicSize;
        m_Width = m_Height * Camera.main.aspect;

        for (int i = 0; i < m_Speed; i++)
        {
            transform.position += m_Normallized * Time.deltaTime;

            if (transform.position.y > m_Height || transform.position.y < -m_Height)
            {
                m_Normallized.y = m_Normallized.y * -1;
                m_Speed = Mathf.Clamp(m_Speed + 2f, 0, m_MaxSpeed);
            }

            if (transform.position.x > m_Width || transform.position.x < -m_Width)
            {
                m_Normallized.x = m_Normallized.x * -1;

                m_Speed = Mathf.Clamp(m_Speed + 2f, 0 , m_MaxSpeed);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m_Normallized = NormallizeVectors(clickPosition, transform.position);
        }
    }

    public void Collision()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
    }
}