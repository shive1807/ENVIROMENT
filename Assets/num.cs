/*using UnityEngine;
using System.Collections;

public class number : MonoBehaviour {
	public int countText;
	public int winText;
	private int count;
	// Use this for initialization
	void Start () {
		count = 0;
		SetCountText ();
		countText.int= "";
	}

	// Update is called once per frame
	void Update () {

	}
	void onTriggerEnter(Collider other)
	{
		if other.gameObject.CompareTag("shootable")
		{
			count = count + 1;
			SetCountText ();
		}
	}
	void SetCountText(){ 
		countText.int = "count" + count.ToString ();
		if (count >= 12) {
			winText.int = "you win"; 
		}
	}}
*/

