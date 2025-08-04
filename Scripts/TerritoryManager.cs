using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TerritoryManager : MonoBehaviour
{
    public static float FriendlyUnitsTotal;
    public static float EnemyUnitsTotal;

    public LayerMask layerMask;
    public GameObject _panelUI;

    public static bool isSelected;

    public RaycastHit hit;

    private Ray ray;

    private Vector3 l, l1, l2, l3, l4, l5;

    private int G, G1, G2, G3, G4, G5;

    public GameObject sheepPrefab;

    public Land_ID gScript;

    public bool _MovingExistingUnits;

    public GameObject enemyBase;
    private Land_ID enemyBaseScript;

    public GameObject[] SendEnemyTo = new GameObject[5];
    private int RandomLandPicked;

    public int[] wool;

    void Start()
    {
        enemyBaseScript = enemyBase.GetComponent<Land_ID>();

        _panelUI.SetActive(false);

        global::MoveUnits.isPressed = false;

        _MovingExistingUnits = false;
    }

    void Update()
    {
        StartCoroutine(MoveEnemyUnits());
        print("Move is pressed " + global::MoveUnits.isPressed);
        if (Input.GetMouseButtonDown(0) && !global::MoveUnits.isPressed && !_panelUI.activeSelf && !_MovingExistingUnits)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) //check which territory is selected
            {
                gScript = hit.collider.gameObject.GetComponent<Land_ID>();

                switch (gScript.ID)
                {
                    case 1:
                        
                        G = gScript._units.Count;
                        if (G > 5)
                        {
                            gScript.numberOfUnits_txt.text = "Units: 5/5    Wools 0/5";
                            break;
                        }
                        else { gScript.numberOfUnits_txt.text = "Units: " + G.ToString() + "/5    Wools 0/10";
                            break;
                        }

                        
                    case 2:
                        
                        G1 = gScript._units.Count;
                        if (G1 > 5)
                        {
                            gScript.numberOfUnits_txt.text = "Units: 5/5";
                            break;
                        }
                        else { gScript.numberOfUnits_txt.text = "Units: " + G1.ToString() + "/5"; }
                        
                        break;
                    case 3:
                        System.Random r = new System.Random();
                        RandomLandPicked = r.Next(1, 6);
                        G2 = gScript._units.Count;
                        if (G2 > 5)
                        {
                            gScript.numberOfUnits_txt.text = "Units: 5/5     Wools 3/5";
                            break;
                        }
                        else
                        {
                            gScript.numberOfUnits_txt.text = "Units: " + G2.ToString() + "/5 " + "Wools "+ "/10";

                            break;
                        }
                    case 4:
                        
                        G3 = gScript._units.Count;
                        if (G3 > 5)
                        {
                            gScript.numberOfUnits_txt.text = "Units: 5/5";
                            break;
                        }
                        else
                        {
                            gScript.numberOfUnits_txt.text = "Units: " + G3.ToString() + "/5";

                            break;
                        }
                    case 5:
                        
                        G4 = gScript._units.Count;
                        if (G4 > 5)
                        {
                            gScript.numberOfUnits_txt.text = "Units: 5/5";
                            break;
                        }
                        else
                        {
                            gScript.numberOfUnits_txt.text = "Units: " + G4.ToString() + "/5";

                            break;
                        }
                    case 6:
                        
                        G5 = gScript._units.Count;
                        if (G5 > 5)
                        {
                            gScript.numberOfUnits_txt.text = "Units: 5/5";
                            break;
                        }
                        else
                        {
                            gScript.numberOfUnits_txt.text = "Units: " + G5.ToString() + "/5";

                            break;
                        }
                }

                _panelUI.SetActive(true);
                Time.timeScale = 0;

            }
        }
        
    }

    public void MoveUnits(Vector3 location)
    {
       
        if (gScript._units == null)
        {
            return;
        }

        List<GameObject> z = gScript._units; // this is the selcted territory's units

        //print("Number of units moving" + z.Count);

        for (int i = 0; i < z.Count; i++)
        {
            // this is to ammend exisiting sheep
            gScript._units[i].GetComponent<NavMeshAgent>().SetDestination(location);
            gScript._units.RemoveAt(i);

        }

        if ( z.Count == 0 && gScript.hasBeenSetADestination) //check if the list of the units on the selected land is 0 (empty)
        {
            global::MoveUnits.isPressed = false;
        }
    }

    IEnumerator MoveEnemyUnits()
    {
       

        if(enemyBaseScript != null)
        {
            if (enemyBaseScript.ID == 1 & enemyBaseScript._enemyUnits.Count > 2)
            {

                switch (RandomLandPicked)
                {                
                    case 2:

                        if(enemyBaseScript._enemyUnits.Count > 3)
                        {
                            enemyBaseScript._enemyUnits[1].GetComponent<NavMeshAgent>().SetDestination(SendEnemyTo[0].transform.position);
                            enemyBaseScript._enemyUnits.RemoveAt(1);
                            yield return new WaitForSeconds(3f);
                        }

                        break;

                    case 3:
                        if(enemyBaseScript._enemyUnits.Count > 3)
                        {
                            enemyBaseScript._enemyUnits[1].GetComponent<NavMeshAgent>().SetDestination(SendEnemyTo[1].transform.position);
                            enemyBaseScript._enemyUnits.RemoveAt(1);
                            yield return new WaitForSeconds(3f);
                        }

                        break;

                    case 4:
                        if(enemyBaseScript._enemyUnits.Count > 3)
                        {
                            enemyBaseScript._enemyUnits[1].GetComponent<NavMeshAgent>().SetDestination(SendEnemyTo[2].transform.position);
                            enemyBaseScript._enemyUnits.RemoveAt(1);
                            yield return new WaitForSeconds(3f);
                        }

                        break;

                    case 5:
                        if(enemyBaseScript._enemyUnits.Count > 3)
                        {
                            enemyBaseScript._enemyUnits[1].GetComponent<NavMeshAgent>().SetDestination(SendEnemyTo[3].transform.position);
                            enemyBaseScript._enemyUnits.RemoveAt(1);
                            yield return new WaitForSeconds(3f);
                        }

                        break;
                    case 6:
                        if(enemyBaseScript._enemyUnits.Count > 3)
                        {
                            enemyBaseScript._enemyUnits[1].GetComponent<NavMeshAgent>().SetDestination(SendEnemyTo[4].transform.position);
                            enemyBaseScript._enemyUnits.RemoveAt(1);
                            yield return new WaitForSeconds(3f);
                        }

                        break;
                }
            }
        }

    }

    //calculate the taotal of wools coming from each land (logic not working yet)
    //public int WoolTotal( int[] wool)
    //{
    //    int totalWools = 0;
    //    foreach (int i in wool)
    //    {
    //        totalWools += i;
    //    }
    //    return totalWools;
    //}
}
