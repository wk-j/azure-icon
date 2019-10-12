open System.IO

let icons = DirectoryInfo("PlantUML").GetFiles("*.puml", SearchOption.AllDirectories)

printfn "| Include | Command  | Icon |"
printfn "|--|--|--|"

for item in icons do
    let fullName = item.FullName
    let title = Path.GetFileNameWithoutExtension(fullName)
    let name = Path.GetFileName(fullName)
    let dir = Path.GetDirectoryName(fullName)
    let dirName = item.Directory.Name


    let png =
        "PlantUML/{dir}/{name}" .Replace("{dir}", dirName) .Replace("{name}", title + ".png")

    let md = "![]({png})".Replace("{png}", png)

    let include =
        "`!include <azure/{dir}/{title}>`"
            .Replace("{dir}", dirName)
            .Replace("{title}", name)
    let command =
        "`{title}`"
            .Replace("{title}", title)

    if File.Exists png then
        printfn "|%s|%s|%s|" include command md
