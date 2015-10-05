using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MainCamera : MonoBehaviour
{
	public static Camera Instance { get; private set; }
	
	public Transform MyTransform { get; private set; }
	
	
	void Awake()
	{
		Instance = GetComponent<Camera>();
		MyTransform = transform;
	}
}
