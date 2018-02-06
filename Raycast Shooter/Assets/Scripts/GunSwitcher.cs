using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour {

    private int selectedWeapon = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon < transform.childCount - 1)
            {
                selectedWeapon++;
                SelectWeapon();
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedWeapon > 0)
            {
                selectedWeapon--;
                SelectWeapon();
            }
        }
	}

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            } else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

}
