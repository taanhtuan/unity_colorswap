using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanController : MonoBehaviour
{
    ColorSwap colorSwap;
    private enum SwapIndex
    {
        Primary = 64,
        Secondary = 128
    }

    public enum PlayerWeapons { Default, MagnetBeam, BombMan, CutMan, ElecMan, FireMan, GutsMan, IceMan };
    public PlayerWeapons playerWeapon = PlayerWeapons.Default;

    void Awake()
    {
        // color swap component to change megaman's palette
        colorSwap = GetComponent<ColorSwap>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetWeapon(playerWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDebugInput();
    }

    void SelectColorScheme(int primaryColor, int secondaryColor)
    {
        /* ColorSwap and Shader to change MegaMan's color scheme
         * 
         * his spritesheets have been altered to greyscale for his outfit
         * Red 64 for the helmet, gloves, boots, etc ( SwapIndex.Primary )
         * Red 128 for his shirt, pants, etc ( SwapIndex.Secondary )
         * 
         * couple ways to code this but I settled on #2
         * 
         * #1 using Lists
         * 
         * var colorIndex = new List<int>();
         * var playerColors = new List<Color>();
         * colorIndex.Add((int)SwapIndex.Primary);
         * colorIndex.Add((int)SwapIndex.Secondary);
         * playerColors.Add(ColorSwap.ColorFromIntRGB(64, 64, 64));
         * playerColors.Add(ColorSwap.ColorFromIntRGB(128, 128, 128));
         * colorSwap.SwapColors(colorIndex, playerColors);
         * 
         * #2 using SwapColor as needed then ApplyColor
         * 
         * colorSwap.SwapColor((int)SwapIndex.Primary, ColorSwap.ColorFromInt(0x0073F7));
         * colorSwap.SwapColor((int)SwapIndex.Secondary, ColorSwap.ColorFromInt(0x00FFFF));
         * colorSwap.ApplyColor();
         * 
         * Also, we'll change the color of our weapon energy bar
         * and adjust the energy value as given in the playerWeaponsStruct
         * 
         */
        // swap color
        colorSwap.SwapColor((int)SwapIndex.Primary, ColorSwap.ColorFromInt(primaryColor));
        colorSwap.SwapColor((int)SwapIndex.Secondary, ColorSwap.ColorFromInt(secondaryColor));
        colorSwap.ApplyColor();
    }

    public void SetWeapon(PlayerWeapons weapon)
    {
        // set new selected weapon (determines color scheme)
        playerWeapon = weapon;

        // apply new selected color scheme with ColorSwap and set weapon energy bar
        switch (playerWeapon)
        {
            case PlayerWeapons.Default:
                // dark blue, light blue; the player weapon energy doesn't apply but we'll just set the default and hide it
                SelectColorScheme(0x0073F7, 0x00FFFF);
                break;
            case PlayerWeapons.MagnetBeam:
                // dark blue, light blue
                SelectColorScheme(0x0073F7, 0x00FFFF);
                break;
            case PlayerWeapons.BombMan:
                // green, light gray
                SelectColorScheme(0x009400, 0xFCFCFC);
                break;
            case PlayerWeapons.CutMan:
                // dark gray, light gray
                SelectColorScheme(0x747474, 0xFCFCFC);
                break;
            case PlayerWeapons.ElecMan:
                // dark gray, light yellow
                SelectColorScheme(0x747474, 0xFCE4A0);
                break;
            case PlayerWeapons.FireMan:
                // dark orange, yellow gold
                SelectColorScheme(0xD82800, 0xF0BC3C);
                break;
            case PlayerWeapons.GutsMan:
                // orange red, light gray
                SelectColorScheme(0xC84C0C, 0xFCFCFC);
                break;
            case PlayerWeapons.IceMan:
                // dark blue, light gray
                SelectColorScheme(0x2038EC, 0xFCFCFC);
                break;
        }
    }

    void PlayerDebugInput()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetWeapon((PlayerWeapons)UnityEngine.Random.Range(0, Enum.GetValues(typeof(PlayerWeapons)).Length));
            Debug.Log("Set random weapon");
        }
    }
}
