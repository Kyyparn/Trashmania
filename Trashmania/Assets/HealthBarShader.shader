Shader "Unlit/HealthBarShader"
{
    Properties
    {
        _MainTex ("Bar Texture", 2D) = "white" {}
		_HealthyColor ("Healthy Color", Color) = (1,1,1,1)
		_DamagedColor ("Damaged Color", Color) = (1,1,1,1)
		_HealthPercent ("Health Percent", float) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float _HealthPercent;
			float4 _HealthyColor;
			float4 _DamagedColor;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
				if (i.uv.x < _HealthPercent) {
					col *= _HealthyColor;
				}
				else {
					col *= _DamagedColor;
				}
                return col;
            }
            ENDCG
        }
    }
}
