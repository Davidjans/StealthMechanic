using UnityEngine;
using System.Collections;
using RootMotion.Dynamics;

public class Jump : MonoBehaviour {

	public Rigidbody r;
	public Vector3 velocity = Vector3.up;

	public PuppetMaster puppetMaster;

	private bool jumpFlag;

	void Start() {
		// All rigidbodies need to be set to Interpolate
		r.interpolation = RigidbodyInterpolation.Interpolate;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) jumpFlag = true;
	}

	// BN! This script needs to be added to a higher value than PuppetMaster in the Script Execution Order so it could overwrite rigidbody velocities!
	// Animator update mode must be on AnimatePhysics
	void FixedUpdate() {
		if (jumpFlag) {
			r.velocity = velocity;

			// Also set velocities for all the muscles
			foreach (Muscle m in puppetMaster.muscles) {
				m.rigidbody.velocity = velocity;
			}

			jumpFlag = false;
		}
	}
}
