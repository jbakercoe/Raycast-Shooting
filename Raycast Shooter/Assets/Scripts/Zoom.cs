using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

    [SerializeField] private GameObject scopeScreen;
    [SerializeField] private GameObject weaponCamera;
    [SerializeField] private Camera mainCamera;

    private bool isScoped = false;
    private float scopedFOV = 10f;
    private float normalFOV;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1))
        {
            Scope();
        }
		
	}

    void Scope()
    {
        isScoped = !isScoped;
        if (!isScoped)
        {
            scopeScreen.gameObject.SetActive(false);
            weaponCamera.gameObject.SetActive(true);
            mainCamera.fieldOfView = normalFOV;
        }
        anim.SetBool("IsScoped", isScoped);
    }

    public void EngageScopeScreen()
    {
        scopeScreen.gameObject.SetActive(true);
        weaponCamera.gameObject.SetActive(false);

        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

}
