using Scripts.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance = null;

	public FMODUnity.StudioEventEmitter Music;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void MenuTheme () {
	    Music.SetParameter ("ExitMenu", 0f);
    }
	public void ExitMenu () {
        Music.SetParameter ("ExitMenu", 1f);
    }

    public void OnOvenFixed(TrashType trashType) {
        switch (trashType) {
            case TrashType.Burnable:
                PaperFixed();
                break;
            case TrashType.Glass:
                GlassFixed();
                break;
            case TrashType.Organic:
                FoodFixed();
                break;
            case TrashType.Metal:
                MetalFixed();
                break;
        }
    }

    public void OnOvenBroken(TrashType trashType) {
        switch (trashType) {
            case TrashType.Burnable:
                PaperBroken();
                break;
            case TrashType.Glass:
                GlassBroken();
                break;
            case TrashType.Organic:
                FoodBroken();
                break;
            case TrashType.Metal:
                MetalBroken();
                break;
        }
    }

    public void ResetOvenStates() {
        GlassFixed();
        MetalFixed();
        FoodFixed();
        PaperFixed();
    }

    public void GlassBroken () {
	    Music.SetParameter ("GlassBroken", 1f);
    }
	public void GlassFixed () {
	    Music.SetParameter ("Glassbroken", 0f);
    }
	public void MetalBroken () {
	    Music.SetParameter ("MetalBroken", 1f);
    }
	public void MetalFixed () {
	    Music.SetParameter ("MetalFixed", 0f);
    }
	public void PaperBroken () {
	    Music.SetParameter ("PaperBroken", 1f);
    }
	public void PaperFixed () {
	    Music.SetParameter ("PaperBroken", 0f);
    }
	public void FoodBroken () {
	    Music.SetParameter ("FoodBroken", 1f);
    }
	public void FoodFixed () {
	    Music.SetParameter ("FoodBroken", 0f);
    }
    public void Death() {
        Music.SetParameter("Death", 1f);
    }
    public void Live() {
        Music.SetParameter("Death", 0f);
    }
}