namespace DotDelay.Lib
open Microsoft.Xna.Framework

type MainGame() as this =
  inherit Game()
  let _graphics = new GraphicsDeviceManager(this)
  let flash = new Flash(this, new Vector2(0.0f, 0.0f))
  // MUST come after the let binding, or the let binding is excecuted after the do, and the do is not executed in a fully initialized object.
  do
    this.Content.RootDirectory <- "Content"
    this.graphics.IsFullScreen <- false
    this.setSize(new Vector2(1028.0f, 720.0f))
    this.IsMouseVisible <- true
    this.Window.Title <- "DotDelay Experiment"
  member this.setSize(size : Vector2) =
    this.graphics.PreferredBackBufferWidth <- (size.X |> int)
    this.graphics.PreferredBackBufferHeight <- (size.Y |> int)
    try this.graphics.ApplyChanges() with | :? System.NullReferenceException -> ()
  member this.graphics with get() : GraphicsDeviceManager = _graphics
  override this.Initialize() =
    flash.Initialize()
    base.Initialize()
  override this.LoadContent() =
    flash.LoadContent()
    base.LoadContent()
  override this.Update(gameTime) =
    flash.Update(gameTime)
    base.Update(gameTime)
  override this.Draw(gameTime) =
    this.graphics.GraphicsDevice.Clear(Color.CornflowerBlue)
    flash.Draw(gameTime)
    base.Draw(gameTime)