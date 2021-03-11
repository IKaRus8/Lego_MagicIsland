using Cinemachine;
using Unity.LEGO.Behaviours.Triggers;
using Unity.LEGO.Minifig;
using UnityEngine;

public class SlideController : MonoBehaviour
{
	public GameObject nearbyTrigger;

	public new CinemachineVirtualCamera camera;

	public Vector3 forward;

	public Vector3 side;

	public bool isSlide;

	private new Rigidbody rigidbody;

	int direction
	{
		get
		{
			int result = 0;

			if (Input.GetKey(KeyCode.A))
			{
				result -= 1;
			}

			if (Input.GetKey(KeyCode.D))
			{
				result += 1;
			}

			return result;
		}
	}

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();

		nearbyTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += StartSlide;
	}

	private void Update()
	{
		if (isSlide)
		{
			Vector3 toDir = side * direction;

			rigidbody.AddForce((forward + toDir) * Time.deltaTime);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "speedTrigger")
		{
			StopSreedForce();
		}
	}

	private void StartSlide()
	{
		rigidbody.useGravity = true;
		camera.gameObject.SetActive(true);

		isSlide = true;
	}

	public void StopSlide()
	{
		camera.gameObject.SetActive(false);

		isSlide = false;

		Destroy(gameObject);
	}

	public void StopSreedForce()
	{
		forward = Vector3.zero;
	}
}
