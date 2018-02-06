using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour {

    private int selectedWeapon = 0;
    private Animator anim;

	// Use this for initialization
	void Start () {
        SelectWeapon();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon < transform.childCount - 1)
            {
                selectedWeapon++;
                anim.GetComponent<Animator>().SetTrigger("Change");
                //SelectWeapon();
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedWeapon > 0)
            {
                selectedWeapon--;
                anim.GetComponent<Animator>().SetTrigger("Change");
                //SelectWeapon();
            }
        }
	}

    public void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                anim = weapon.GetComponent<Animator>();
                anim.SetTrigger("Start");
            } else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

}
