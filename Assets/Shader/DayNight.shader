Shader "Custom/DayNight"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Night ("Night", 2D) = "white" {}
        _Water ("Water", 2D) = "white" {}
        _BumpMap ("Normal", 2D) = "white" {}
        _BumpScale ("Bumpiness", Range(0,1)) = 0.5
        _EquatorThickness ("Equator Thickness", Range(0,1)) = 0.5
        _EquatorColor ("Equator Color", Color) = (1,1,1,1)
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Contrast ("Contrast", Range(0,1)) = 0.0
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
        sampler2D _Night;
        sampler2D _Water;
        sampler2D _BumpMap;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldNormal;
            INTERNAL_DATA
        };

        float _BumpScale;
        half _Glossiness;
        half _EquatorThickness;
        half _Metallic;
        half _Contrast;
        fixed4 _Color;
        fixed4 _EquatorColor;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {

            float3 worldNormal = WorldNormalVector (IN, float3(0,0,1));

            half night = max(0, dot(worldNormal, -_WorldSpaceLightPos0.xyz));
            night = pow(night,0.3);

            half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
            half darkSide = step(nl, 0);
            nl = saturate((1-nl)-darkSide);

            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = tex2D (_Water, IN.uv_MainTex) * _Glossiness;
            o.Alpha = c.a;
            o.Normal = UnpackScaleNormal(tex2D (_BumpMap, IN.uv_MainTex), _BumpScale); 
            //o.Normal = worldNormal;
            float equator = step(abs(IN.uv_MainTex.y*2-1),_EquatorThickness*0.5) * nl;

            o.Emission = tex2D (_Night, IN.uv_MainTex) * night * 2.0 + equator * _EquatorColor.rgb * _EquatorColor.a + nl * _Contrast;

            //o.Emission = nl;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
