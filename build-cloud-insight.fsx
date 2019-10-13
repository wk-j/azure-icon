open System.IO

let icons = DirectoryInfo("./CloudInsight").GetFiles("*.png")

printfn "| Include | Command  | Icon |"
printfn "|--|--|--|"

for item in icons do
    let fullName = item.FullName
    let title = Path.GetFileNameWithoutExtension(fullName)
    let name = Path.GetFileName(fullName)
    let dir = Path.GetDirectoryName(fullName)
    let dirName = item.Directory.Name

    let png =
        "{dir}/{name}"
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

    printfn "|%s|%s|%s|" includes command md
