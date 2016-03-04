Shader "langlang/texMoveAlpha" {
	Properties {
	    _Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_AlphaTex ("AlphaTex", 2D) = "white" {}
		_ScrollXSpeed("Xspeed",Range(0,10))=0
		_ScrollYSpeed("Yspeed",Range(0,10))=0
	}
	SubShader {
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha

		sampler2D _MainTex;
		sampler2D _AlphaTex;
		fixed4 _Color;
		fixed _ScrollXSpeed;
		fixed _ScrollYSpeed;

		struct Input {
			float2 uv_MainTex;
			float2 uv_AlphaTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
		    fixed2 scrollUV=IN.uv_MainTex;
		    fixed xScrollValue=_ScrollXSpeed*_Time;
		    fixed yScrollValue=_ScrollYSpeed*_Time;
		    scrollUV+=fixed2(xScrollValue,yScrollValue);
			half4 c = tex2D (_MainTex, scrollUV)* _Color;
			half d = tex2D (_AlphaTex, IN.uv_AlphaTex).a;
			o.Albedo = c.rgb;
			o.Alpha = d;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
