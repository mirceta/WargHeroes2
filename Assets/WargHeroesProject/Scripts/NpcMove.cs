using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMove : MonoBehaviour {

	[SerializeField] // with this you can expose the parameter to the unity editor
	Transform _destination;

	NavMeshAgent _navMeshAgent;

	#region [unity events] 

	// Use this for initialization
	void Start () {
		_navMeshAgent = this.GetComponent<NavMeshAgent> ();

		if (_navMeshAgent == null) {
			Debug.LogError ("The nav mesh agent component is not attached to " + gameObject.name);
		} 
		else {
			SetDestination();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#endregion
	#region [auxiliary]
	private void SetDestination() {
		if (_destination != null) {
			Vector3 targetVector = _destination.transform.position;
			_navMeshAgent.SetDestination (targetVector);
		}
	}
	#endregion




}
