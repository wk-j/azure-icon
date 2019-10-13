open System.IO
open System.Text

let icons = DirectoryInfo("./icon/Office").GetFiles("*.png", SearchOption.AllDirectories)
let builder = StringBuilder()

builder.AppendLine("## Office")
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
        "../icon/Office/{dir}/{name}"
            .Replace("{dir}", dirName)
            .Replace("{name}", name)

    let md =
        "![]({png})"
            .Replace("{png}", png)

    let includes =
        "`!include <office/{dir}/{title}>`"
            .Replace("{dir}", dirName)
            .Replace("{title}", title)

    let command =
        "`{title}`"
            .Replace("{title}", "OFF_" + title.ToUpper())

    let line = sprintf "|%s|%s|%s|" includes command md
    builder.AppendLine line |> ignore

File.WriteAllText("md/Office.md", builder.ToString())
