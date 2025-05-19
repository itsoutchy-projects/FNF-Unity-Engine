# Contributing Guide
Thanks for reading this, I suppose you want to contribute to this engine. Well here are some guidelines I want you to follow.

## Comments
I need clear and concise comments.
DO NOT:
```cs
string sprite = File.ReadAllBytes(sprite.assetPath); // Get the asset
Texture2D newSpr = new Texture2D(sprite); // make texure
Sprite realSprite = Sprite.Create(newSpr, new Rect(new Vector2(newSpr.width, newSpr.height), Vector2.Zero) ...); // Create sprite
GameObject obj = new GameObject(sprite.name); // Create the GameObject
SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>(); // Add the sprite
stageObjs.Add(obj); // Add the object to the list
...
```
While I did ask for comments, do not comment every single line you add, instead do:
```cs
string sprite = File.ReadAllBytes(sprite.assetPath); // Get the asset
Texture2D newSpr = new Texture2D(sprite);
Sprite realSprite = Sprite.Create(newSpr, new Rect(new Vector2(newSpr.width, newSpr.height), Vector2.Zero) ...); // Create sprite

GameObject obj = new GameObject(sprite.name);
SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>(); // Add the sprite

stageObjs.Add(obj);
```
DO NOT:
```cs
// add that or smth idk
Stage stage = Loader.LoadStage(AssetPaths.GetStagePath(meta.playData.stage));
foreach (StageSprite spr in stage.props) {
  // idk loop or smth
  ...
}
```
This doesn't say much, I need to know what it's supposed to do, instead do:
```cs
// Load the stage
Stage stage = Loader.LoadStage(AssetPaths.GetStagePath(meta.playData.stage));
foreach (StageSprite spr in stage.props) {
  // Loop over all the sprites
  ...
}
```

## Closing
Don't close your PRs unless you *really* think its bad or unecessary, I'll review it and decide whether I should add it or close it.

## Other stuff
Be specific in the comments on your PR, when I ask for something, but its ambigous, feel free to provide everything.
