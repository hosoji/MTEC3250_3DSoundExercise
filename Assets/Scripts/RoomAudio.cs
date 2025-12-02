using UnityEngine;
using UnityEngine.Audio;

public class RoomAudio : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixerSnapshot arcadeSnapshot;
    public AudioMixerSnapshot neighborSnapshot;
    public AudioMixerSnapshot poolSnapshot;
    public AudioMixerSnapshot hallwallSnapshot;

    float doorOpenCutoff = 5000f;
    float doorCLosedCutoff = 360f;

    void OnEnable()
    {
        Door.DoorOpening += OpenDoor;
        Door.DoorClosing += CloseDoor;
    }

    void OnDisable()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OpenDoor(float time, Door door)
    {
        audioMixer.SetFloat(door.GetComponentInParent<Room>().roomName + "DoorCutoff", doorOpenCutoff);
    }
    void CloseDoor(float time, Door door)
    {
        audioMixer.SetFloat(door.GetComponentInParent<Room>().roomName + "DoorCutoff", doorCLosedCutoff);
    }
}
