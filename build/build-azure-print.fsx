open System.IO
open System.Text


let icons = DirectoryInfo("icon/Azure").GetFiles("*.puml", SearchOption.AllDirectories)
let builder = StringBuilder()

builder.AppendLine "## Azure"
builder.AppendLine()
builder.AppendLine("```")
builder.AppendLine("!include <azure/AzureCommon.puml>")
builder.AppendLine("!include <azure/AzureSimplified.puml>")
builder.AppendLine()

// builder.AppendLine "| Include | Command  | Icon |"
// builder.AppendLine "|--|--|--|"

for item in icons do
    let fullName = item.FullName
    let title = Path.GetFileNameWithoutExtension(fullName)
    let name = Path.GetFileName(fullName)
    let dir = Path.GetDirectoryName(fullName)
    let dirName = item.Directory.Name


    let png =
        "icon/Azure/{dir}/{name}" .Replace("{dir}", dirName) .Replace("{name}", title + ".png")

    let md = "![](../{png})".Replace("{png}", png)

    let includes =
        "!include <azure/{dir}/{title}>"
            .Replace("{dir}", dirName)
            .Replace("{title}", name)

    // let command =
    //     "`{title}`"
    //         .Replace("{title}", title)

    if File.Exists png then
        let line = sprintf "%s" includes
        builder.AppendLine line |> ignore

builder.AppendLine("```")

File.WriteAllText("markdown/AzureIncludes.md", builder.ToString())
