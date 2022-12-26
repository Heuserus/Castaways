Shader "Custom/WaterShader"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _WaveStrength("Wave Strength", Range(0.01, 1)) = 0.5
        _WaveSpeed("Wave Speed", Range(0.1, 5)) = 1
        _WaveFrequency("Wave Frequency", Range(0.1, 5)) = 1
    }

    SubShader
    {
        // Use alpha blending for the water surface
        Blend SrcAlpha OneMinusSrcAlpha

        // Set the material to be transparent
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }

        // Use a simple diffuse lighting model
        Lighting Off

        // Set up the main pass for the water surface
        Pass
        {
            // Bind the main texture and set its tiling and offset properties
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _WaveStrength;
            float _WaveSpeed;
            float _WaveFrequency;

            float4 frag(v2f i) : COLOR
            {
                // Add a waving effect to the main texture using the wave strength, speed, and frequency properties
                float2 uv = i.uv + _WaveStrength * sin(_WaveFrequency * i.uv.y + _Time.y * _WaveSpeed);
                return tex2D(_MainTex, uv);
            }
            ENDCG
        }
    }
}
