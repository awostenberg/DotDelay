namespace DotDelay.Lib
open System.Diagnostics
open Microsoft.Xna.Framework

[<AllowNullLiteral>]
type FlashTracker(game, pos : Vector2, delayTimes : float list) =
  // delayTimes is a list of time to wait for each succession
  inherit GameObject(game)
  
  // Keeps track of how many times there has been a flash
  let mutable itr = 0
  // Could use GameTime provided, but StopWatch better fits the program's needs
  let stopWatch = new Stopwatch()
  let mutable flash : Flash = null
  let mutable delaying = false
  
  member this.BasicFlash() =
    flash <- new Flash(game, pos)
    flash.Initialize()
    flash.LoadContent()
  
  member this.Flash() =
    delaying <- true
    stopWatch.Start()
  
  member this.CurrentDelay with get() = delayTimes.Item(itr)
  
  override this.Update(gameTime) =
    if delaying then
      if itr <= (delayTimes.Length - 1) then
        if stopWatch.Elapsed.TotalMilliseconds >= this.CurrentDelay then
          this.BasicFlash()
          stopWatch.Stop()
          stopWatch.Reset()
          delaying <- false
          itr <- itr + 1
    if not (flash = null) then
      flash.Update(gameTime)
      if flash.IsDone() then flash <- null
  
  override this.Draw(gameTime) =
    if not (flash = null) then flash.Draw(gameTime)