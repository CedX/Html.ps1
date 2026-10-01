"Deleting all generated files..."
Remove-Item */obj -Force -Recurse
Remove-Item Binaries, Sources/Generated -ErrorAction Ignore -Force -Recurse
Remove-Item Temp/* -Exclude .gitkeep -Force -Recurse
