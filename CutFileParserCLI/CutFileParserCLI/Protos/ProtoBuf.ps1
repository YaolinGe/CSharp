# PowerShell Script to Generate Protocol Buffers Code

Write-Host "Starting Protocol Buffers code generation..."

# Navigate to the Protos directory
Set-Location -Path $PSScriptRoot

# Generate C# code
Write-Host "Generating C# code from sensor_data.proto..."
& protoc --csharp_out=../ sensor_data.proto

# Generate Python code
Write-Host "Generating Python code from sensor_data.proto..."
& protoc --python_out=../Python/ sensor_data.proto

Write-Host "Protocol Buffers code generation completed."
