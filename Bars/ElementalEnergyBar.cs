//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Terraria;
//using Terraria.GameContent.UI.Elements;
//using Terraria.ModLoader;
//using Terraria.UI;
//using Terraria.GameContent;
//using System.Collections.Generic;
//using TrueSoul.Assets;

//namespace TrueSoul.Bars
//{
	//internal class ElementalEnergyResourceBar : UIState
	//{
		// For this bar we'll be using a frame texture and then a gradient inside bar, as it's one of the more simpler approaches while still looking decent.
		// Once this is all set up make sure to go and do the required stuff for most UI's in the ModSystem class.
	//	private UIText text;
	//	private UIElement area;
		//private UIImage barFrame;
		//private Color gradientA;
		//private Color gradientB;

	//	public override void OnInitialize()
	//	{
		//	// Create a UIElement for all the elements to sit on top of, this simplifies the numbers as nested elements can be positioned relative to the top left corner of this element. 
		//	// UIElement is invisible and has no padding.
		//	area = new UIElement();
		//	area.Left.Set(-area.Width.Pixels - 600, 1f); // Place the resource bar to the left of the hearts.
		//	area.Top.Set(30, 0f); // Placing it just a bit below the top of the screen.
		//	area.Width.Set(182, 0f); // We will be placing the following 2 UIElements within this 182x60 area.
		//	area.Height.Set(60, 0f);

		//	barFrame = new UIImage(ModContent.Request<Texture2D>("ExampleMod/Assets/Bars/BarFra")); // Frame of our resource bar
	//		barFrame.Left.Set(22, 0f);
		//	barFrame.Top.Set(0, 0f);
		//	barFrame.Width.Set(138, 0f);
		//	barFrame.Height.Set(34, 0f);
//
	//		text = new UIText("0/0", 0.8f); // text to show stat
	//		text.Width.Set(138, 0f);
	//		text.Height.Set(34, 0f);
	//		text.Top.Set(40, 0f);
	//		text.Left.Set(0, 0f);
	//
	//		area.Append(text);
	//		area.Append(barFrame);
			//Append(area);
			//
		//}
		
	//	public override void Draw(SpriteBatch spriteBatch)
	//	{
	//		// This prevents drawing unless we are using an ExampleCustomResourceWeapon
//
//				return;
//
//			base.Draw(spriteBatch);
	//	}

		// Here we draw our UI
	//	protected override void DrawSelf(SpriteBatch spriteBatch)
//			base.DrawSelf(spriteBatch);
//
	//		var modPlayer = Main.LocalPlayer.GetModPlayer<ElementalEnergyResourcePlayer>();
	//		// Calculate quotient
	//		float quotient = (float)modPlayer.elementResourceCurrent / modPlayer.elementResourceMax; // Creating a quotient that represents the difference of your currentResource vs your maximumResource, resulting in a float of 0-1f.
	//		quotient = Utils.Clamp(quotient, 0f, 1f); // Clamping it to 0-1f so it doesn't go over that.
//
	//	}

	//	public override void Update(GameTime gameTime)
	//	{

		//		return;

		//	var modPlayer = Main.LocalPlayer.GetModPlayer<ElementalEnergyResourcePlayer>();
		//	// Setting the text per tick to update and show our resource values.
		//	text.SetText($"Example Resource: {modPlayer.elementResourceCurrent} / {modPlayer.elementResourceMax2}");
		//	base.Update(gameTime);
	//	}
	//}

//	class ElementalResourceUISystem : ModSystem
//	{
	//	private UserInterface ElementalResourceBarUserInterface;

	//	internal ElementalEnergyResourceBar ElementalResourceBar;

	//	public override void Load()
	//	{
			// All code below runs only if we're not loading on a server
	//		if (!Main.dedServ)
	//		{
	//			ElementalResourceBar = new();
	//			ElementalResourceBarUserInterface = new();
	//			ElementalResourceBarUserInterface.SetState(ElementalResourceBar);
		//	}
		//}
//
	//	public override void UpdateUI(GameTime gameTime)
	//	{
	//		ElementalResourceBarUserInterface?.Update(gameTime);
	//	}
//
	//	public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
	//	{
	//		int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
		//	if (resourceBarIndex != -1)
		//	{
			//	layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
				//	"TrueSoul: Elemental Resource Bar",
				//	delegate {
					//	ElementalResourceBarUserInterface.Draw(Main.spriteBatch, new GameTime());
					//	return true;
					//},
					//InterfaceScaleType.UI)
				//);
			//}
		//}
	//}
//}