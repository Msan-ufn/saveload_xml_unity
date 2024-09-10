using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;
using UnityEngine;

public class cubotest : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer m_MeshRenderer;
    public ScrGameMaster GameMaster;
    public GameObject self;
    public ClassGhostKey myClassVars;
    private bool MouseClicked = false;
    private float ClickTimeDelayMax = 0.05f;
    private float ClickTimeDelayNow = 0;
    

    void Start()
    {
        myClassVars = new ClassGhostKey();
        myClassVars.GhostID = 0;
        myClassVars.KeyItemID = 0;

        m_MeshRenderer = GetComponent<MeshRenderer>();
        self = this.gameObject;

        GameMaster = GameObject.FindWithTag("GameMaster").GetComponent<ScrGameMaster>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
           // Debug.Log("Mouse clicked");
            ClickTimeDelayNow = ClickTimeDelayMax;
            MouseClicked = true;
        }
        else if (ClickTimeDelayNow > 0)
        {
            Debug.Log(ClickTimeDelayNow);
            ClickTimeDelayNow -=Time.deltaTime;              
        }else MouseClicked = false;

       // Debug.Log(MouseClicked);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("RayCastPlayer"))
        {
           // Debug.Log("Colisão de Raycast");
            if (MouseClicked)
            {
                //m_MeshRenderer.enabled = false;
                GameMaster.MeshTurnOff(self);

            }
        }


    }

}
