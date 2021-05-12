using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partition : MonoBehaviour
{
	public enum eState
	{
		STOP,
		PLAY
	}


	public int bpm = 60;
	public int nbBeat = 6;

	public eState state { get; set; }

	public Transform BeatPrefab;
	private Beat[] BeatArray;
	public float time = 0;

	// Start is called before the first frame update
	void Start()
	{
		BeatArray = new Beat[nbBeat];
		for (int i = 0; i < nbBeat; i++)
        {
			Vector3 pos = transform.position + (i - nbBeat / 2) * new Vector3(BeatPrefab.localScale.x/2, 0, 0);
			BeatArray[i] = Instantiate(BeatPrefab, pos, Quaternion.identity).GetComponent<Beat>();
		}
	}

	// Update is called once per frame
	private float nextTimer = 0;
	private int currentIndex = 0;
	void Update()
	{
		float delayBetweenBeatSec = bpm / 60;
		time += Time.deltaTime;

		if (time > nextTimer - BeatArray[currentIndex].AnnimationStartingTime)
        {
			BeatArray[currentIndex].Activate();
			currentIndex++;
			if (currentIndex >= nbBeat)
				currentIndex = 0;
			nextTimer = bpm / 60; // TODO apply measure
			time = 0;
		}
	}
}
