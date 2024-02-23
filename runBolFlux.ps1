param(
    [int]$start,
    [int]$end
)

# Loop from $start to $end to run create bol flow automated tests
$start..$end | ForEach-Object {
    Write-Host "Running test with tag @$_"
    dotnet test --filter Category=$_
    if (-not $?) {
        Write-Host "Test---> @$_ failed. Stopping execution."
        break
    }
}
