using UnityEngine;
using System.Collections;

public class StaticMethods : MonoBehaviour {

	public static class Boundary
	{
		public static float xMin;
		public static float xMax;
		public static float zMin;
		public static float zMax;
	}
	
	public static Vector3 InsideFrustumCheck(Vector3 pos, Renderer _renderer)
	{
	//	Vector3 center = new Vector3(Screen.width*0.5f, Screen.height*0.5f, pos.z);
		Vector3 heading = pos - Camera.main.transform.position;
		float distance = Vector3.Dot (heading, Camera.main.transform.forward);
		float frustumHeight = 2.0f * distance * Mathf.Tan (Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
		float frustumWidth = frustumHeight * Camera.main.aspect;

		Boundary.xMin = -frustumWidth / 2;
		Boundary.xMax = frustumWidth / 2;
		Boundary.zMin = -frustumHeight / 2;
		Boundary.zMax = frustumHeight / 2;

		pos.x = Mathf.Clamp (pos.x, -frustumWidth/2f + _renderer.bounds.size.x, frustumWidth/2f - _renderer.bounds.size.x);
		pos.z = Mathf.Clamp (pos.z, -frustumHeight/2f + _renderer.bounds.size.z, frustumHeight/2f - _renderer.bounds.size.z);
		//Debug.Log (pos);
		return pos;
	}
}
