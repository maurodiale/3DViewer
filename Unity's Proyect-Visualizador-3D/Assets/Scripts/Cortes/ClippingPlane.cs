using UnityEngine;

// Comentar la linea de abajo, tira cortes en runtime
//[ExecuteAlways] // para ejecutarse en edición tambien
public class ClippingPlane : MonoBehaviour
{
	//material we pass the values to
	//public Material mat;
	
	private Plane plane;

	private void Start()
	{
		plane = new Plane(transform.up, transform.position);
	}

	private void Update ()
	{
		plane.SetNormalAndPosition(transform.up, transform.position);

		//create plane
		//Plane plane = new Plane(transform.up, transform.position);
		//transfer values from plane to vector4
		Vector4 planeRepresentation = new Vector4(plane.normal.x, plane.normal.y, plane.normal.z, plane.distance);
		//pass vector to shader. Esto solo afecta a los GO que tengan el material mat
		//mat.SetVector("_Plane", planeRepresentation);
		// Si el GO tiene un material que tiene un shader con _Plane, se ve afectado
		Shader.SetGlobalVector("_Plane", planeRepresentation);
	}
}