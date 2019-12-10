using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;
using RootMotion.Dynamics;

public class TeleportTest : MonoBehaviour {

    public Transform target;
    public Transform cameraRig;
    public PuppetMaster puppetMaster;
    public VRIK ik;

    private bool teleportFlag = false;

    private void Start()
    {
        puppetMaster.OnRead += OnPuppetMasterRead;
    }

    void OnPuppetMasterRead()
    {
        if (teleportFlag)
        {
            cameraRig.position = target.position + Vector3.up * 1.8f;
            
            ik.solver.Reset();

            teleportFlag = false;
        }
    }

    void Update () {
	    if (Input.GetKeyDown(KeyCode.T))
        {
            teleportFlag = true;
            puppetMaster.Teleport(target.position, target.rotation, true);
        }
	}
}
