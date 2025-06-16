Shader "Unlit/LineRenderer"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _InterpValue("Interp",float) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _InterpValue;

            v2f vert (MeshData v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 green = float3(0.0,1.0,0.0);
                float3 red = float3(1.0,0.0,0.0);
                float3 col = lerp(green,red,_InterpValue);
                return fixed4(col,1);
            }
            ENDCG
        }
    }
}
