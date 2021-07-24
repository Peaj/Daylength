Shader "Custom/Sun"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Speed ("Speed", Vector) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed4 _Speed;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));

            float2 offset1 = _Speed.xy * _Time.x;
            float2 offset2 = _Speed.zw * _Time.x;
            // Albedo comes from a texture tinted by color
            fixed4 c1 = tex2D (_MainTex, IN.uv_MainTex + offset1);
            fixed4 c2 = tex2D (_MainTex, IN.uv_MainTex + offset2);
            fixed4 c = c1 * c2 * (1-rim) + rim * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = 0;
            o.Smoothness = 0;
            o.Alpha = 1;
            o.Emission = c;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
