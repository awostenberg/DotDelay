namespace DotDelay.Lib
open Microsoft.Xna.Framework

type Flash(game, x : int, y : int) =
  member this.X = x
  member this.Y = y