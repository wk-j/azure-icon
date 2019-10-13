open System.IO
open System.Text

let icons = DirectoryInfo("icon/CloudInsight").GetFiles("*.png")
let builder = StringBuilder()

builder.AppendLine("## Cloud Insight")
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
        "../icon/{dir}/{name}"
            .Replace("{dir}", dirName)
            .Replace("{name}", name)

    let md =
        "![]({png})"
            .Replace("{png}", png)

    let includes =
        "`!include <cloudinsight/{title}>`"
            .Replace("{title}", title)

    let command =
        "`<${title}>`"
            .Replace("{title}", title)

    let line = sprintf "|%s|%s|%s|" includes command md
    builder.AppendLine line |> ignore

File.WriteAllText("md/CloudInsight.md", builder.ToString())
