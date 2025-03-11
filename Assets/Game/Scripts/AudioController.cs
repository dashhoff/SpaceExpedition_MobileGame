using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [SerializeField] private AudioSource _oneShotSource;
    [SerializeField] private AudioSource _loopingSource;
    [SerializeField] private List<AudioClip> _clips;

    private readonly Dictionary<string, AudioClip> _clipDict = new();
    private readonly HashSet<string> _loopingSounds = new();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        foreach (var clip in _clips)
        {
            _clipDict[clip.name] = clip;
        }
    }

    private void OnEnable()
    {
        /*EventController.Victory += OnVictory;
        EventController.Defeat += OnDefeat;
        EventController.Instance.OnFuelPickup += OnFuelPickup;
        EventController.Instance.OnOxygenPickup += OnOxygenPickup;
        EventController.Instance.UFOStartedChasing += OnUFOStartChase;
        EventController.Instance.UFOStoppedChasing += OnUFOStopChase;*/
    }

    private void OnDisable()
    {
        /*EventController.Instance.Victory -= OnVictory;
        EventController.Instance.Defeat -= OnDefeat;
        EventController.Instance.OnFuelPickup -= OnFuelPickup;
        EventController.Instance.OnOxygenPickup -= OnOxygenPickup;
        EventController.Instance.UFOStartedChasing -= OnUFOStartChase;
        EventController.Instance.UFOStoppedChasing -= OnUFOStopChase;*/
    }

    private void PlaySound(string soundName)
    {
        if (_clipDict.TryGetValue(soundName, out var clip))
        {
            _oneShotSource.PlayOneShot(clip);
        }
    }

    private void StartLoop(string soundName)
    {
        if (_loopingSounds.Contains(soundName)) return;

        if (_clipDict.TryGetValue(soundName, out var clip))
        {
            _loopingSource.clip = clip;
            _loopingSource.loop = true;
            _loopingSource.Play();
            _loopingSounds.Add(soundName);
        }
    }

    private void StopLoop(string soundName)
    {
        if (_loopingSounds.Contains(soundName))
        {
            _loopingSource.Stop();
            _loopingSounds.Remove(soundName);
        }
    }

    private void OnVictory() => PlaySound("Victory");
    private void OnDefeat() => PlaySound("Defeat");
    private void OnFuelPickup() => PlaySound("FuelPickup");
    private void OnOxygenPickup() => PlaySound("OxygenPickup");
    private void OnUFOStartChase() => StartLoop("UFOChase");
    private void OnUFOStopChase() => StopLoop("UFOChase");
}
