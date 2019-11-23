using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

	public FMODUnity.StudioEventEmitter Music;
	public void MenuTheme () {
	Music.SetParameter ("ExitMenu", 0f);
}
	 public void ExitMenu () {
	Music.SetParameter ("ExitMenu", 1f);
}
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
