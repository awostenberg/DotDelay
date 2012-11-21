namespace DotDelay.Lib
open Microsoft.Xna.Framework

type MainGame() as this =
  inherit Game()
  let _graphics = new GraphicsDeviceManager(this)
  // MUST come after the let binding, or the let binding is excecuted after the do, and the do is not executed in a fully initialized object.
  do
    this.Content.RootDirectory <- "Content"
    this.graphics.IsFullScreen <- false
    this.IsMouseVisible <- true
    this.Window.Title <- "DotDelay Experiment"
  member this.graphics with get() : GraphicsDeviceManager = _graphics
  override this.Initialize() = base.Initialize()
  override this.Update(gameTime) = base.Update(gameTime)
  override this.Draw(gameTime) =
    this.graphics.GraphicsDevice.Clear(Color.CornflowerBlue)
    base.Draw(gameTime)