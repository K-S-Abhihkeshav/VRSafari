using UnityEngine;
using TMPro;  // Import TextMeshPro namespace
using System.Collections.Generic;  // Required for Dictionary

public class VRSubtitleRaycast : MonoBehaviour
{
    public TextMeshProUGUI subtitleText; // Change to TMP type
    public float maxDistance = 200f;
    public float subtitleDisplayTime = 10f;
    private float timer = 0f;

    private Dictionary<string, string> keywordDescriptions = new Dictionary<string, string>
    {
        { "Deer", "Wild herbivore found in forests." },
        { "Horse", "Domesticated animal used for riding & work." },
        { "Chicken", "Domesticated bird raised for eggs & meat." },
        { "Wolf", "Wild carnivore that hunts in packs." }
    };

    void Update()
    {
        // Raycast from the center of the camera
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider != null)
            {
                //subtitleText.text = "" + hit.collider.gameObject.name;
                foreach (var entry in keywordDescriptions)
                {
                    if (hit.collider.gameObject.name.ToLower().Contains(entry.Key.ToLower()))
                    {
                        subtitleText.text = entry.Key+": "+entry.Value;
                    }
                
                }
                timer = subtitleDisplayTime; // Reset timer
            }
        }
        else
        {
            // Countdown to clear text
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0) subtitleText.text = "";
            }
        }
    }
}
