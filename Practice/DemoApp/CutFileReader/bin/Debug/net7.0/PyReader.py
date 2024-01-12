from sensor_data_pb2 import SensorDataList, SensorDataEntry
import pandas as pd

def read_protobuf(file_path):
    sensor_data_list = SensorDataList()

    with open(file_path, "rb") as file:
        sensor_data_list.ParseFromString(file.read())

    # Convert to a Python list or a Pandas DataFrame for further processing
    data = [(data.time_span, data.value) for data in sensor_data_list.data]
    df = pd.DataFrame(data, columns=["TimeSpan", "Value"])
    return df

# Example usage
df = read_protobuf("sensor_data.protobuf")
print(df)
