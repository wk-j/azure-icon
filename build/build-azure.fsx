open System.IO
open System.Text


let icons = DirectoryInfo("icon/Azure").GetFiles("*.puml", SearchOption.AllDirectories)
let builder = StringBuilder()

builder.AppendLine "## Azure"
builder.AppendLine()
builder.AppendLine "| Include | Command  | Icon |"
builder.AppendLine "|--|--|--|"

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
        "`!include <azure/{dir}/{title}>`"
            .Replace("{dir}", dirName)
            .Replace("{title}", name)
    let command =
        "`{title}`"
            .Replace("{title}", title)

    if File.Exists png then
        let line = sprintf "|%s|%s|%s|" includes command md
        builder.AppendLine line |> ignore

File.WriteAllText("md/Azure.md", builder.ToString())
