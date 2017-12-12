using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room2 : MonoBehaviour {
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject door;
    public GameObject waypoint;
    //public Quaternion target = Quaternion.Euler(new Vector3(0, 30, 0));
    private enum States { normal, rotate1, rotate2, rotate3, door1};
    private States myState;
    private Quaternion rotation1; private int count1 = 0;
    private Quaternion rotation2; private int count2 = 0;
    private Quaternion rotation3; private int count3 = 0;
    private Quaternion rotation4;
    public void Rotate_object1()
    {
        myState = States.rotate1;
        rotation1 = object1.transform.rotation * Quaternion.Euler(0F, 0F, -90F);
        count1++;
    }

    public void Rotate_object2()
    {
        myState = States.rotate2;
        rotation2 = object2.transform.rotation * Quaternion.Euler(0F, 0F, -90F);
        count2++;
    }

    public void Rotate_object3()
    {
        myState = States.rotate3;
        rotation3 = object3.transform.rotation * Quaternion.Euler(0F, 0F, -90F);
        count3++;
    }

    public void Open_door()
    {
        myState = States.door1;
        waypoint.SetActive(true);
    }
    // Use this for initialization
    void Start()
    {
        myState = States.normal;

    }

    // Update is called once per frame
	void Update () {
        if (myState == States.rotate1)
        {
            object1.transform.rotation = Quaternion.Lerp(object1.transform.rotation, rotation1, 10 * Time.deltaTime);
        }

        else if (myState == States.rotate2)
        {
            object2.transform.rotation = Quaternion.Lerp(object2.transform.rotation, rotation2, 10 * Time.deltaTime);
        }

        else if (myState == States.rotate3)
        {
            object3.transform.rotation = Quaternion.Lerp(object3.transform.rotation, rotation3, 10 * Time.deltaTime);
        }
        else if (myState == States.door1)
        {
            door.transform.rotation = Quaternion.Lerp(door.transform.rotation, Quaternion.Euler(0F, 360F, 0F), 2 * Time.deltaTime);

        }
        if (count1 % 4 == 3 && count2 % 4 == 1 && count3 % 4 == 3)
        {

            Invoke("Open_door", 1);
        }
    }

   
}
