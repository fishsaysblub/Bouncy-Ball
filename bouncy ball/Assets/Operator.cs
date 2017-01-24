using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Operator : MonoBehaviour
{
    [SerializeField]
    private List<moceToMouse> m_Balls = new List<moceToMouse>();

    [SerializeField]
    private List<CubeMovement> m_Box = new List<CubeMovement>();

    void Start()
    {

    }

    void LateUpdate()
    {
        //ball collision
        for (int i = 0; i < m_Balls.Count; i++)
        {
            Vector3 ball1 = m_Balls[i].transform.position;
            float radius1 = m_Balls[i].m_Radius;

            for (int j = 0; j < m_Balls.Count; j++)
            {
                Vector3 ball2 = m_Balls[j].transform.position;
                float radius2 = m_Balls[j].m_Radius;

                bool collision = false;
                if (i != j)
                {
                    collision = CircleCollisions(ball1, ball2, radius1, radius2);
                }

                if (collision == true)
                {
                    m_Balls[i].Collision();
                    m_Balls[j].Collision();
                }
            }
        }
        //box in box check
        for (int i = 0; i < m_Box.Count; i++)
        {
            Vector3 box1 = m_Box[i].transform.position;
            float RightSide1 = m_Box[i].transform.localScale.x / 2;
            float TopSide1 = m_Box[i].transform.localScale.y / 2;

            for (int j = 0; j < m_Box.Count; j++)
            {
                Vector3 box2 = m_Box[j].transform.position;
                float RightSide2 = m_Box[j].transform.localScale.x / 2;
                float TopSide2 = m_Box[j].transform.localScale.x / 2;

                bool collision = false;
                if (i != j)
                {
                    collision = BoxInBoxCollision(box1, box2, RightSide1, TopSide1, RightSide2, TopSide2);
                }

                if (collision == true)
                {
                    m_Box[i].Collision();
                    m_Box[j].Collision();
                }
            }
        }
    }

    bool CircleCollisions(Vector3 one, Vector3 two, float radius1, float radius2)
    {
        float awnser = Mathf.Sqrt((one.x - two.x) * (one.x - two.x) + (one.y - two.y) * (one.y - two.y));
        float radiusdistance = radius1 + radius2;

        bool collision = false;
        if (awnser <= radiusdistance)
        {
            collision = true;
        }

        return collision;
    }

    bool BoxInBoxCollision(Vector3 one, Vector3 two, float rightSide1, float topSide1, float rightSide2, float topSide2)
    {
        float lowestSide1 = -topSide1;
        float leftSide1 = -rightSide1;
        float lowestSide2 = -topSide2;
        float leftSide2 = -rightSide2;

        bool collision = false;

        if (one.x + rightSide1 > two.x + leftSide2 && one.x + leftSide1 < two.x + rightSide2 && one.y + lowestSide1 < two.y + topSide2 && one.y + topSide1 > two.y + lowestSide2)
        {
            collision = true;
        }
        



        return collision;
    }
}

