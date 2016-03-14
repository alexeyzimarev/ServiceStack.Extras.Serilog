// include Fake libs
#r "src/packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.Paket
open Fake.FileUtils
open System

// Directories
let rootDir = currentDirectory
let buildDir  = currentDirectory + "/bin/"
let nugetDir = currentDirectory + "/nuget/"

let nugetApiKey = environVar "BAMBOO_nugetApiKey"
let nugetPublishUrl = environVar "BAMBOO_nugetPublishUrl"
let nugetVersion = getBuildParamOrDefault "nugetVersion" null

// Filesets
let appReferences  =
    !! "src/**/*.csproj"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; nugetDir]
    MSBuildRelease buildDir "Clean" appReferences
        |> Log "Clean-Output: "
)

Target "BuildApp" (fun _ ->
    MSBuildRelease buildDir "Build" appReferences
        |> Log "BuildApp-Output: "
)

Target "Push" (fun _ ->
    Push (fun p ->
        {p with
            ApiKey = nugetApiKey
            PublishUrl = nugetPublishUrl
            WorkingDir = nugetDir
            TimeOut = TimeSpan.FromSeconds(5.0)
        })
)

Target "Pack" (fun _ ->
    Pack (fun p ->
        let p' = {p with OutputPath = nugetDir; WorkingDir = rootDir + "/src" }
        if nugetVersion = null then p' else {p' with Version = nugetVersion }
        )
)

// Build order
"Clean"
  ==> "BuildApp"
  ==> "Pack"
  ==> "Push"

// start build
RunTargetOrDefault "Build"
