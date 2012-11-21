namespace DotDelay.Lib
open Microsoft.Xna.Framework

[<AbstractClass>]
type GameObject(game : Game) =
  member this.game = game
  // Initialize other game object here -- called after LoadContent
  abstract Initialize : unit default this.Initialize = ()
  // Load all resources
  abstract LoadContent : unit default this.LoadContent = ()
  // Execute computational code
  abstract Update : GameTime -> unit default this.Update(gameTime) = ()
  // Draw the object's state
  abstract Draw : GameTime -> unit default this.Draw(gameTime) = ()