using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Land_ID : MonoBehaviour
{
    public int ID;

    public TextMeshProUGUI numberOfUnits_txt;

    private Objectbehaviour _objectBehaviourScript;

    public bool isSpawning;

    private int allowedNumberOfSheepSpawned = 5;

    private Vector3 spawningOffset = new Vector3(0f, -1f, -3f);

    public GameObject friendlySheepPrefab;
    public GameObject enemySheepPrefab;
    public GameObject spawningPosition;

    public Material _m;

    private Renderer _renderer;

    public  List<GameObject> _units;
    public   List<GameObject> _enemyUnits;
    public int _firendlyUnitsNumber;
    public int _enemyUnitsNumber;

    public int myTerritory = 0;

    public bool hasBeenSetADestination;

    
    private void Start()
    {    
        _units = new List<GameObject>();
        _renderer = this.GetComponent<Renderer>();

        _m = _renderer.material;
        _m.color = Color.white;

        hasBeenSetADestination = false;
        
    }

    private void Update()
    {
        //check who won/lost the game using number of units on each side

        if(ID == 1)
        {
            if( _units.Count > _enemyUnits.Count)
            {
                print("I won");
            }
        }
        else if(ID == 3)
        {
            if(_enemyUnits.Count > _units.Count)
            {
                print("You've lost");
            }
            
        }

        //StartCoroutine(WoolGenerator());
        CheckIfMyTerritory();
        CheckIfMyEnemyTerritory();
    }

    private void OnMouseDown() //select a destination to move units when a left mouse button is pressed
    {
        TerritoryManager tManager = FindAnyObjectByType<TerritoryManager>();

        if (MoveUnits.isPressed && !hasBeenSetADestination)
        {
            Vector3 location = gameObject.transform.position;
            tManager.MoveUnits(location);
            hasBeenSetADestination = true;
            MoveUnits.isPressed = false;
        }
        
    }

    //reset units moving to no units moving (after onmousedown/selecting the destination for the previous units)
    private void OnMouseUp()
    {
        //if(MoveUnits.isPressed)
        hasBeenSetADestination = false;
        TerritoryManager territoryManager = FindAnyObjectByType<TerritoryManager>();
        territoryManager._MovingExistingUnits = false;
    }

    //private void OnTriggerEnter(Collider col) //check what type of units entering the territory (player's/opponent's)
    //{
    //    if (col.gameObject.tag == "Unit")
    //    {
    //        col.gameObject.transform.position = transform.position;
    //        if (_enemyUnits.Count > 0)
    //        {
    //            _enemyUnits.RemoveAt(0);

    //        }
    //        if (_enemyUnits.Count == 0)
    //        {
    //            _units.Add(friendlySheepPrefab);

    //        }
    //    }

    //    if (col.gameObject.tag == "EnemyUnit")
    //    {
    //        col.gameObject.transform.position = transform.position;
    //        if (_units.Count > 0)
    //        {
    //            //_units.RemoveAt(0);

    //        }
    //        if (_units.Count == 0)
    //        {
    //            _enemyUnits.Add(enemySheepPrefab);

    //        }
    //    }
    //}


    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Unit")
        {
            if(_units.Count >= allowedNumberOfSheepSpawned)
            {
                Destroy(col.gameObject);
                _units.RemoveAt(5);
            }
            if (_enemyUnits.Count > 0)
            {
                Destroy(_enemyUnits[0]);
                _enemyUnits.RemoveAt(0);
                Destroy(col.gameObject); 
            }
            else
            {
                _units.Add(col.gameObject);
                col.gameObject.GetComponent<NavMeshAgent>().destination = transform.position;
            }
        }
        if(col.tag == "EnemyUnit")
        {
            if(_enemyUnits.Count >= allowedNumberOfSheepSpawned){
                Destroy(col.gameObject);
                _enemyUnits.RemoveAt(5);

            }
            if(_units.Count > 0)
            {
                Destroy(_units[0]);
                _units.RemoveAt(0);
                Destroy(col.gameObject);
            }
            else
            {
                _enemyUnits.Add(col.gameObject);
                col.gameObject.GetComponent<NavMeshAgent>().destination = transform.position;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(_units.Count < 3)
        {
            if(other.tag == "Unit")
            {
                isSpawning = false;
            }
        }
        if (_enemyUnits.Count < 3)
        {
            if (other.tag == "EnemyUnit")
            {
                isSpawning = false;
            }
        }
    }

    public void CheckIfMyTerritory() //check if it's player territory by checking the number of units and change colour accordingly
    {
        if (_units.Count > _enemyUnits.Count)
        {
            _m.color = Color.red; 

            if (allowedNumberOfSheepSpawned > _units.Count)
            {
                StartCoroutine(InstantiateUnits());
            }  
        }
    }

    public void CheckIfMyEnemyTerritory()
    {
        if (_enemyUnits.Count > _units.Count)
        {
            _m.color = Color.blue;

            if (allowedNumberOfSheepSpawned > _enemyUnits.Count)
            {
                
                StartCoroutine(InstantiateEnemyUnits());
            }
            
        }
  
    }

    
    IEnumerator InstantiateUnits()
    {

        if (isSpawning == false && ID == 3)
        {
            isSpawning = true; 
            GameObject newSheep = Instantiate(friendlySheepPrefab, spawningPosition.transform.position + spawningOffset, Quaternion.identity, this.transform);

            //_units.Add(newSheep);
            yield return new WaitForSeconds(2f);

            if (_units.Count < allowedNumberOfSheepSpawned)
            {

                isSpawning = false;
            }
        }

        else if (isSpawning == false && ID == 1)
        {
            isSpawning = true;
            GameObject newSheep = Instantiate(friendlySheepPrefab, spawningPosition.transform.position + spawningOffset, Quaternion.identity, this.transform);

            //_units.Add(newSheep);
            yield return new WaitForSeconds(2f);

            if (_units.Count < allowedNumberOfSheepSpawned)
            {

                isSpawning = false;
            }

        }

    }

    IEnumerator InstantiateEnemyUnits()
    {

        if (isSpawning == false && ID == 1)
        {
            isSpawning = true;
            GameObject enemySheep = Instantiate(enemySheepPrefab, spawningPosition.transform.position + spawningOffset, Quaternion.identity, this.transform);
           
            //_enemyUnits.Add(enemySheepPrefab);
            yield return new WaitForSeconds(2f);


            if (_enemyUnits.Count < allowedNumberOfSheepSpawned)
            {
                isSpawning = false;
            }

        }

        if (isSpawning == false && ID == 3)
        {
            isSpawning = true;
            GameObject newSheep = Instantiate(enemySheepPrefab, spawningPosition.transform.position + spawningOffset, Quaternion.identity, this.transform);

            //_units.Add(newSheep);
            yield return new WaitForSeconds(2f);

            if (_units.Count < allowedNumberOfSheepSpawned)
            {

                isSpawning = false;
            }
        }
    }

    //wool generator on each land (not working yet)
    //IEnumerator WoolGenerator()
    //{
    //    TerritoryManager tmanager = FindAnyObjectByType<TerritoryManager>();

    //    //tmanager.WoolTotal(_wool[0]);

    //    yield return new WaitForSeconds(5f);
    //}
}
