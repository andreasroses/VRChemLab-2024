Shader "URP/OutlineVer2"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1, 1, 1, 1)
        _MainTex ("Main Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
        _OutlineWidth ("Outline Width", Range(0.001, 0.1)) = 0.01
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent+1" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            Name "Outline"
            Cull Front
            ZWrite Off
            //Blend One OneMinusSrcColor // Render the backfaces only for the outline
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            // Properties
            sampler2D _MainTex;
            float4 _BaseColor;
            float4 _OutlineColor;
            float _OutlineWidth;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            // Vertex shader
            v2f vert(appdata v)
            {
                v2f o;
                
                // Offset vertex position along normal direction to create outline
                float3 worldNormal = mul((float3x3)unity_ObjectToWorld, v.normal);
                float3 offsetPos = v.vertex.xyz + worldNormal * _OutlineWidth;
                
                // Transform the vertex to clip space
                o.pos = UnityObjectToClipPos(float4(offsetPos, 1.0));
                o.color = _OutlineColor; // Use outline color for this pass
                o.uv = v.uv;

                return o;
            }

            // Fragment shader for outline
            half4 frag(v2f i) : SV_Target
            {
                return i.color; // Output the outline color
            }
            ENDHLSL
        }

        Pass
        {
            Name "MainPass"
            Cull Back  // Render the main object normally
            ZWrite On
            //Blend SrcAlpha OneMinusSrcAlpha
            HLSLPROGRAM
            #pragma vertex vertMain
            #pragma fragment fragMain
            #include "UnityCG.cginc"

            // Properties
            sampler2D _MainTex;
            float4 _BaseColor;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vertMain(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 fragMain(v2f i) : SV_Target
            {
                half4 mainColor = tex2D(_MainTex, i.uv) * _BaseColor;
                return mainColor;
            }
            ENDHLSL
        }
    }

    Fallback "Diffuse"
}
