#!/bin/bash

echo "Starting Protocol Buffers code generation..."

# Navigate to the Protos directory
cd "$(dirname "$0")"

# Generate C# code
echo "Generating C# code from sensor_data.proto..."
protoc --csharp_out=../ sensor_data.proto

# Generate Python code
echo "Generating Python code from sensor_data.proto..."
protoc --python_out=../Python/ sensor_data.proto

echo "Protocol Buffers code generation completed."
