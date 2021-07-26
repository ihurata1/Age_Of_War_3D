using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    public GameObject[] turrets;
    int selectedTurret = 1;
    // Start is called before the first frame update
    void Start()
    {
        turrets = GameManager.Instance().allTurrets;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("TurretZone"))
                {
                    
                    if (Buttons.selectedTurretIndex < 0)
                    {
                        
                        hit.collider.gameObject.GetComponent<TurretZone>().RemoveTurret();

                    }
                    else
                    {
                        hit.collider.gameObject.GetComponent<TurretZone>().AddTurret(turrets[Buttons.selectedTurretIndex]);

                    }
                }
            }
        }

    }
}
