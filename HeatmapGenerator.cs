using UnityEngine;
using System.Collections.Generic;

// Struct to hold heatmap data
public struct HeatmapDataPoint
{
    public Vector3 position; // Position of the data point
    public float intensity; // Normalized intensity (0-1)

    public HeatmapDataPoint(Vector3 pos, float inten)
    {
        position = pos;
        intensity = inten;
    }
}

public class HeatmapGenerator : MonoBehaviour
{
    public ParticleSystem heatmapParticleSystem; // Reference to the Particle System

    // Emit particles based on provided data points
    public void EmitHeatmapData(List<HeatmapDataPoint> dataPoints)
    {
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        
        foreach (var dataPoint in dataPoints)
        {
            emitParams.position = dataPoint.position; // Set particle position
            emitParams.startSize = Mathf.Lerp(0.1f, 2.0f, dataPoint.intensity); // Lerp for size variation
            emitParams.startColor = Color.Lerp(Color.blue, Color.red, dataPoint.intensity); // Lerp for color variation from blue (low) to red (high)

            heatmapParticleSystem.Emit(emitParams, 1); // Emit one particle per data point
        }
    }

    // Example data generation
    void Start()
    {
        List<HeatmapDataPoint> exampleDataPoints = new List<HeatmapDataPoint>
        {
            new HeatmapDataPoint(new Vector3(0, 0, 0), 0.1f),
            new HeatmapDataPoint(new Vector3(1, 0, 0), 0.5f),
            new HeatmapDataPoint(new Vector3(2, 0, 0), 1.0f)
        };

        EmitHeatmapData(exampleDataPoints); // Call this function to emit particles based on the data points
    }
}
