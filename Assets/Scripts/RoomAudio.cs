using UnityEngine;
using UnityEngine.Audio;

public class RoomAudio : MonoBehaviour
{
    public FPController player;
    public AudioMixer audioMixer;
    public AudioMixerSnapshot arcadeSnapshot;
    public AudioMixerSnapshot neighborSnapshot;
    public AudioMixerSnapshot poolSnapshot;
    public AudioMixerSnapshot hallwallSnapshot;

    public float transitionTime = 0;
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
        player = GameObject.Find("Player").GetComponent<FPController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.CurrentSurface == null) return;

        if (player.CurrentSurface.CompareTag("Arcade"))
        {
            arcadeSnapshot.TransitionTo(transitionTime);
        }else if (player.CurrentSurface.CompareTag("Neighbor"))
        {
            neighborSnapshot.TransitionTo(transitionTime);
        }else if (player.CurrentSurface.CompareTag("Pool"))
        {
            poolSnapshot.TransitionTo(transitionTime);
        }else
        {
            hallwallSnapshot.TransitionTo(transitionTime);
        }
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
