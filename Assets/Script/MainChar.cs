using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChar : MonoBehaviour
{
    public class Character : MainCharecterObject
    {
        public override int SetHealth
        {
            get
            {
                Debug.Log("GET; Abstract, must override in inheritated class");
                return Health;
            }
            set
            {
                Debug.Log("SET; Abstract, must override in inheritated class");
                Health = value;
            }
        }

        public void getBom ()
        {
            Debug.Log(BomCount);
            Debug.Log("extra from inheritated class");
           
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Character main = new Character();

        if (Input.GetKeyDown(KeyCode.K))
        {
            main.SetHealth = 100;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            int temp = main.SetHealth;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            main.getBom();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            main.getBom();
        }

    }
}
