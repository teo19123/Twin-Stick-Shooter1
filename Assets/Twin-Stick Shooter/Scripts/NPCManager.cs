using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;

    public GameObject m_NPCPrefab;
    public int m_maxNPCAmount;
    public List<NPCController> m_NPCList = new List<NPCController>();
    public float m_NPCSpeed = 5f;
    public Vector2 m_playerLocation;
    public Vector2 m_verticalBounds;
    public Vector2 m_horizontalBounds;
    public float m_spawmPadding = 1;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        SpawnNPC();

    }

    // Update is called once per frame
    void Update()
    {
        ManageNPC();
    }

    public void SpawnNPC()
    {
        for (int i = m_NPCList.Count; i < m_maxNPCAmount; ++i)
        {
            GameObject temp = Instantiate(m_NPCPrefab);
            m_NPCList.Add(temp.GetComponent<NPCController>());

        }
    }
    public void ManageNPC()
    {
        m_playerLocation = GameObject.FindGameObjectWithTag("Player").transform.position;

        foreach (NPCController nC in m_NPCList)
        {
            nC.m_movementSpeed = m_NPCSpeed;

            nC.m_targetMoveLocation = m_playerLocation;
        }
    }

    void GetScreenBounds()
    {
        float verticalBounds = Camera.main.orthographicSize;
        float horizontalBounds = verticalBounds * Screen.width / Screen.height;
        float tempVertical = verticalBounds + m_spawmPadding;
        float tempHorizontal = horizontalBounds + m_spawmPadding;

     
    }
}


