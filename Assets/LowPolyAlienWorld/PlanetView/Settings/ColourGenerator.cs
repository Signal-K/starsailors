using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGenerator {
    ColourSettings settings;
    Texture2D texture;
    const int textureResolution = 50;

    public void UpdateSettings(ColourSettings settings) {
        this.settings = settings;
        if (texture == null || texture.height != settings.biomeColourSettings.biomes.Length) {
            texture = new Texture2D(textureResolution, settings.biomeColourSettings.biomes.Length);
        }
    }

    public void UpdateElevation(MinMax elevationMinMax) {
        settings.planetMaterial.SetVector("_elevationMinMax", new Vector4(elevationMinMax.Min, elevationMinMax.Max));
    }

    public float BiomePercentFromPoint(Vector3 pointOnUnitSphere) {
        // Return value of 0 if in first biome, 1 if in last biome
        float heightPercent = (pointOnUnitSphere.y + 1) / 2f;
        float biomeIndex = 0;
        int numBiomes = settings.biomeColourSettings.biomes.Length;

        for (int i = 0; i < numBiomes; i++) {
            if (settings.biomeColourSettings.biomes[i].startHeight < heightPercent) {
                biomeIndex = i;
            } else {
                break;
            }
        }

        return biomeIndex / Mathf.Max(1, numBiomes - 1);
    }

    public void UpdateColours() {
        Color[] colours = new Color[texture.width * texture.height];
        int colourIndex = 0;
        foreach (var biome in settings.biomeColourSettings.biomes) {
            for (int i = 0; i < textureResolution; i++) {
                Color gradientCol = biome.gradient.Evaluate(i / (textureResolution - 1f));
                Color tintCol = biome.tint;
                colours[colourIndex] = gradientCol * (1 - biome.tintPercent) + tintCol * biome.tintPercent;
                colourIndex++;
            }
        }
        texture.SetPixels(colours);
        texture.Apply();
        settings.planetMaterial.SetTexture("_texture", texture);
    }
}