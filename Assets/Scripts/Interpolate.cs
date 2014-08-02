using UnityEngine;
using System.Collections;

public struct Packet {
	public Vector3 position;
	public Quaternion rotation;
	public double timestamp;
}

public class Interpolate : MonoBehaviour {
	private Packet latestFrame;
	private Packet lastAppliedFrame;
	private double progress = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(latestFrame.timestamp != 0 && lastAppliedFrame.timestamp != 0) {
			double diff = latestFrame.timestamp - lastAppliedFrame.timestamp;
			diff = progress/diff;
			transform.position = Vector3.Lerp(lastAppliedFrame.position, latestFrame.position, (float)diff);
			transform.rotation = Quaternion.Slerp(lastAppliedFrame.rotation, latestFrame.rotation, (float)diff);
			progress += Time.deltaTime;
		} else if(latestFrame.timestamp != 0) {
			transform.position = latestFrame.position;
			transform.rotation = latestFrame.rotation;
		}
	}

	public void AddPacket(Packet packet) {
		lastAppliedFrame = latestFrame;
		latestFrame = packet;
		progress = 0;

	}

	public void AddPacket(double timestamp, Vector3 pos, Quaternion rotation) {
		Packet newPacket = new Packet();
		newPacket.position = pos;
		newPacket.rotation = rotation;
		newPacket.timestamp = timestamp;
		AddPacket(newPacket);
	}
}
