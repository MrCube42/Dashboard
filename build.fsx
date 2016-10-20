#I @"packages/build/FAKE/tools/"
#r @"FakeLib.dll"
// #r @"packages/Mono.Cecil/lib/net45/Mono.Cecil.dll"
#I "packages/build/SourceLink.Fake/tools/"
// #load "packages/build/SourceLink.Fake/tools/SourceLink.fsx"

open Fake
open System.IO


let binDir = "bin"
let buildDir = binDir </> "build"

let cwd = System.IO.Directory.GetCurrentDirectory()
Log "Wotrking in ..." [ cwd ]

Target "Clean" (fun _ -> 
    CleanDirs [ buildDir ]
)

Target "BuildApp" (fun _ ->
  MSBuildRelease buildDir "Build" ["./Devinmotion.Dashboard.sln"]
  |> Log "App build output: "
)

Target "Default" DoNothing

// Dependencies
"Clean"
  ==> "BuildApp"
  ==> "Default"

RunTargetOrDefault "Default"
