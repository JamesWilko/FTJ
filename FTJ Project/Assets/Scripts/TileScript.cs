using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	public Material multiply;
	
	public Material Bake(){

		Camera camera = transform.FindChild("Camera").camera;
		RenderTexture render_texture = new RenderTexture(256, 256, 24, RenderTextureFormat.Default, RenderTextureReadWrite.Default);
		render_texture.useMipMap = true;
		render_texture.filterMode = FilterMode.Trilinear;
		render_texture.mipMapBias = -0.5f;
		camera.targetTexture = render_texture;
		
		transform.FindChild("Title").gameObject.layer = LayerMask.NameToLayer("Active Card Render Texture");
		transform.FindChild("Rules").gameObject.layer = LayerMask.NameToLayer("Active Card Render Texture");
		
		Transform tile_mesh = transform.FindChild("Tile_base").FindChild("default");
		Material material = new Material(tile_mesh.renderer.material);
		material.mainTexture = render_texture;

		camera.Render();
		
		transform.FindChild("Title").gameObject.layer = LayerMask.NameToLayer("Card Render Texture");
		transform.FindChild("Rules").gameObject.layer = LayerMask.NameToLayer("Card Render Texture");
		
		Material return_material = new Material(multiply);
		return_material.mainTexture = render_texture;

		return return_material;

	}
	
}
