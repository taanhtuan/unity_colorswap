using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    float mHitEffectTimer = 0.0f;
    const float cHitEffectTime = 0.1f;

    ColorSwap colorSwap;
    public enum SwapIndex
    {
        Outline = 25,
        SkinPrim = 254,
        SkinSec = 239,
        HandPrim = 235,
        HandSec = 204,
        ShirtPrim = 62,
        ShirtSec = 70,
        ShoePrim = 253,
        ShoeSec = 248,
        Pants = 72,
    }

    void Awake()
    {
        colorSwap = GetComponent<ColorSwap>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SwapDemoColors();
    }

    // Update is called once per frame
    void Update()
    {
        if (mHitEffectTimer > 0.0f)
        {
            mHitEffectTimer -= Time.deltaTime;
            if (mHitEffectTimer <= 0.0f)
                colorSwap.ResetAllSpritesColors();
        }
    }

    void SwapDemoColors()
    {
        colorSwap.SwapColor((int)SwapIndex.SkinPrim, ColorSwap.ColorFromInt(0xffbd99));
        colorSwap.SwapColor((int)SwapIndex.SkinSec, ColorSwap.ColorFromInt(0x7a3600));
        colorSwap.SwapColor((int)SwapIndex.ShirtPrim, ColorSwap.ColorFromInt(0xb9000b));
        colorSwap.SwapColor((int)SwapIndex.ShirtSec, ColorSwap.ColorFromInt(0x51000b));
        colorSwap.SwapColor((int)SwapIndex.Pants, ColorSwap.ColorFromInt(0x0c0300));
        colorSwap.ApplyColor();
    }
}
