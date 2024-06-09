Shader "Custom/EmissionIntensityShader"
{
    Properties
    {
        _EmissionColor ("Emission Color", Color) = (1, 1, 1, 1)
        _EmissionIntensity ("Emission Intensity", Range(10, 50)) = 1
    }
 
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        fixed4 _EmissionColor;
        float _EmissionIntensity;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Emission = _EmissionColor.rgb * _EmissionIntensity;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
