using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDemo : MonoBehaviour
{
    float mHitEffectTimer = 0.0f;
    const float cHitEffectTime = 0.1f;

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

    SpriteRenderer mSpriteRenderer;
    Texture2D mColorSwapTex;
    Color[] mSpriteColors;

    void Awake()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        InitColorSwapTex();
        SwapDemoColors();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mHitEffectTimer > 0.0f)
        {
            mHitEffectTimer -= Time.deltaTime;
            if (mHitEffectTimer <= 0.0f)
                ResetAllSpritesColors();
        }
    }

    public void StartHitEffect()
    {
        mHitEffectTimer = cHitEffectTime;
        SwapAllSpritesColorsTemporarily(Color.white);
    }

    public void SwapDemoColors()
    {
        //SwapColor(SwapIndex.SkinPrim, ColorFromInt(0x784a00));
        //SwapColor(SwapIndex.SkinSec, ColorFromInt(0x4c2d00));
        //SwapColor(SwapIndex.ShirtPrim, ColorFromInt(0xc4ce00));
        //SwapColor(SwapIndex.ShirtSec, ColorFromInt(0x784a00));
        //SwapColor(SwapIndex.Pants, ColorFromInt(0x594f00));
        //mColorSwapTex.Apply();

        //SwapColor(SwapIndex.SkinPrim, ColorFromInt(0xffbd99));
        //SwapColor(SwapIndex.SkinSec, ColorFromInt(0x7a3600));
        //SwapColor(SwapIndex.ShirtPrim, ColorFromInt(0xb9000b));
        //SwapColor(SwapIndex.ShirtSec, ColorFromInt(0x51000b));
        //SwapColor(SwapIndex.Pants, ColorFromInt(0x0c0300));
        //mColorSwapTex.Apply();

        SwapColor(SwapIndex.SkinPrim, ColorFromInt(0xfef79e));
        SwapColor(SwapIndex.SkinSec, ColorFromInt(0x978f00));
        SwapColor(SwapIndex.ShirtPrim, ColorFromInt(0x17d800));
        SwapColor(SwapIndex.ShirtSec, ColorFromInt(0x014500));
        SwapColor(SwapIndex.Pants, ColorFromInt(0xb28b00));
        mColorSwapTex.Apply();

        //SwapColor(SwapIndex.SkinPrim, Color.black);
        //SwapColor(SwapIndex.SkinSec, Color.black);
        //SwapColor(SwapIndex.ShirtPrim, Color.black);
        //SwapColor(SwapIndex.ShirtSec, Color.black);
        //SwapColor(SwapIndex.Pants, Color.black);
        //SwapColor(SwapIndex.Outline, Color.black);
        //SwapColor(SwapIndex.ShoePrim, Color.black);
        //SwapColor(SwapIndex.ShoeSec, Color.black);
        //SwapColor(SwapIndex.HandPrim, Color.black);
        //SwapColor(SwapIndex.HandSec, Color.black);
        //mColorSwapTex.Apply();
    }

    public static Color ColorFromInt(int c, float alpha = 1.0f)
    {
        int r = (c >> 16) & 0x000000FF;
        int g = (c >> 8) & 0x000000FF;
        int b = c & 0x000000FF;

        Color ret = ColorFromIntRGB(r, g, b);
        ret.a = alpha;

        return ret;
    }

    public static Color ColorFromIntRGB(int r, int g, int b)
    {
        return new Color((float)r / 255.0f, (float)g / 255.0f, (float)b / 255.0f, 1.0f);
    }

    public void InitColorSwapTex()
    {
        Texture2D colorSwapTex = new Texture2D(256, 1, TextureFormat.RGBA32, false, false);
        colorSwapTex.filterMode = FilterMode.Point;

        for (int i = 0; i < colorSwapTex.width; ++i)
            colorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));

        colorSwapTex.Apply();

        mSpriteRenderer.material.SetTexture("_SwapTex", colorSwapTex);

        mSpriteColors = new Color[colorSwapTex.width];
        mColorSwapTex = colorSwapTex;
    }

    public void SwapColor(SwapIndex index, Color color)
    {
        mSpriteColors[(int)index] = color;
        mColorSwapTex.SetPixel((int)index, 0, color);
    }


    public void SwapColors(List<SwapIndex> indexes, List<Color> colors)
    {
        for (int i = 0; i < indexes.Count; ++i)
        {
            mSpriteColors[(int)indexes[i]] = colors[i];
            mColorSwapTex.SetPixel((int)indexes[i], 0, colors[i]);
        }
        mColorSwapTex.Apply();
    }

    public void SwapAllSpritesColorsTemporarily(Color color)
    {
        for (int i = 0; i < mColorSwapTex.width; ++i)
            mColorSwapTex.SetPixel(i, 0, color);
        mColorSwapTex.Apply();
    }

    public void ResetAllSpritesColors()
    {
        for (int i = 0; i < mColorSwapTex.width; ++i)
            mColorSwapTex.SetPixel(i, 0, mSpriteColors[i]);
        mColorSwapTex.Apply();
    }

    public void ClearAllSpritesColors()
    {
        for (int i = 0; i < mColorSwapTex.width; ++i)
        {
            mColorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));
            mSpriteColors[i] = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        mColorSwapTex.Apply();
    }
}
