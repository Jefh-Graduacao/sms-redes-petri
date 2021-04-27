mkdir ./.output/
dotnet publish .\RedesPetri.WinForms\ -r win-x64 -p:PublishSingleFile=true --self-contained true -o .output/