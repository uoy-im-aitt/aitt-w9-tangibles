using System;
using UnityEngine;

public class DJMixer : MonoBehaviour
{
    public AudioClip[] tracks;
    public float offVolume;
    public float onVolume = 1.0f;

    private AudioSource[] _players;

    private void Start()
    {
        InitSources();
    }

    public void PlayTrack(int trackId)
    {
        SetTrackState(trackId, true);
    }

    public void StopTrack(int trackId)
    {
        SetTrackState(trackId, false);
    }

    private void SetTrackState(int trackId, bool playing)
    {
        if (trackId >= 0 && trackId < _players.Length)
        {
            _players[trackId].volume = playing ? onVolume : offVolume;
        }
        else
        {
            throw new IndexOutOfRangeException($"Invalid track ID {trackId}");
        }
    }

    private void InitSources()
    {
        _players = new AudioSource[tracks.Length];
        for (var i = 0; i < tracks.Length; i++)
        {
            var s = gameObject.AddComponent<AudioSource>();
            s.clip = tracks[i];
            s.loop = true;
            s.volume = offVolume;
            s.Play();

            _players[i] = s;
        }
    }
}
