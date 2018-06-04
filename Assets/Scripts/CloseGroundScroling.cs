using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CloseGroundScroling : MonoBehaviour {
		private Transform myTf;
		public GameObject background;
		private bool next = false;
		public float speed;
		// Use this for initialization
		void Start () {
			myTf = this.GetComponent<Transform>(); 
		}

		// Update is called once per frame
		void Update () {

			this.transform.Translate(new Vector2(speed, 0));
			if (myTf.position.x < -45.361f && !next)
			{
				Instantiate(background, new Vector2(-45.663f, -18.72f), new Quaternion());
				next = true;

			}
			if (myTf.position.x < -45f)
			{
				Destroy(this.gameObject);
			}




		}
	}
