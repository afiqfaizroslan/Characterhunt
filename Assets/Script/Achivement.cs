using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Achivement : MonoBehaviour
{
    public GameObject[] badges = new GameObject[4];
    public GameObject[] Characters = new GameObject[6]; 
    public Text point;
    public Text name;
    public Text level;
    public Text pointTonext;
    DAO dao = new DAO();

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
