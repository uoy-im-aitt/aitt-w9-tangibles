using UnityEngine;
using System.Collections;

public class DJMixer : MonoBehaviour 
{
	public AudioClip[] tracks;
    public float offVolume = 0.0f;
    public float onVolume = 1.0f;

	private AudioSource[] players;

	void Start () 
	{
		InitSources ();
	}

	public void SetTrackState(int trackId, bool playing)
	{
		if (trackId >= 0 && trackId < players.Length) 
		{
			players [trackId].volume = playing ? onVolume : offVolume;
		} 
		else 
		{
			print ("Invalid track ID: " + trackId);
		}
	}

	private void InitSources()
	{
		players = new AudioSource[tracks.Length];
		for (int i = 0; i < tracks.Length; i++)
		{
			AudioSource s = this.gameObject.AddComponent<AudioSource>();
			s.clip = tracks[i];
			s.loop = true;
			s.volume = offVolume;
			s.Play();

			players[i] = s;
		}
	}
}
