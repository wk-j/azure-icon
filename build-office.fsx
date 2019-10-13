open System.IO

let icons = DirectoryInfo("./Office").GetFiles("*.png", SearchOption.AllDirectories)

printfn "| Include | Command  | Icon |"
printfn "|--|--|--|"

for item in icons do
    let fullName = item.FullName
    let title = Path.GetFileNameWithoutExtension(fullName)
    let name = Path.GetFileName(fullName)
    let dir = Path.GetDirectoryName(fullName)
    let dirName = item.Directory.Name

    let png =
        "Office/{dir}/{name}"
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

    printfn "|%s|%s|%s|" includes command md
