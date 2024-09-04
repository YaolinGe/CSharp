from ast import PyCF_ALLOW_TOP_LEVEL_AWAIT
import matplotlib.pyplot as plt
import pandas as pd
import plotly.graph_objects as go
from plotly.subplots import make_subplots
import os 


class Plotter:
    def __init__(self, output_path: str=None):
        if output_path is None:
            self.output_path = 'output.png'
        else:
            self.output_path = output_path
        
        output_folder = os.path.dirname(self.output_path)
        if not os.path.exists(output_folder):
            os.makedirs(output_folder)

    def lineplot(self, x, y):
        plt.figure()
        plt.plot(x, y, label='Line Plot')
        plt.scatter(x, y, color='red', label='Scatter Plot')
        plt.legend()
        plt.savefig(self.output_path)

    def plot_anomalies(self, data_file, data_anomaly_file):
        data = pd.read_csv(data_file, header=None, skiprows=1, delimiter=',', dtype=float)
        data.columns = ['Time', 'Accelerometer2_X', 'Accelerometer2_Y', 'Accelerometer2_Z', 'Accelerometer50_X', 'Accelerometer50_Y', 'Strain1', 'Strain2']
        indices_anomaly = pd.read_csv(data_anomaly_file, header=None, skiprows=1, delimiter=',', dtype=float)
        ind_anomaly = indices_anomaly.iloc[:, 0].astype(int).to_numpy()
        error_anomaly = indices_anomaly.iloc[:, 1]
        data_anomaly = data.iloc[ind_anomaly, :]
        
        fig = make_subplots(rows=7, cols=1, shared_xaxes=True, subplot_titles=("Accelerometer X2", "Accelerometer Y2", "Accelerometer Z2", "Accelerometer X50", "Accelerometer Y50", "Strain 1", "Strain 2"))
        self.make_subplots_for_data(data, fig, line_color='black')
        self.make_subplots_for_data(data_anomaly, fig, line_color='red', mode='markers')
        
        fig.update_layout(height=800, width=1350, title_text="Sensor Data", showlegend=False, margin=dict(l=0, r=0, t=0, b=0))
        fig.write_html(self.output_path)    
        print("Image saved to ", self.output_path)
       
    def make_subplots_for_data(self, df, fig, line_color='black', linestyle='solid', mode='lines'):
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Accelerometer2_X'], mode=mode, name='X', line=dict(color=line_color, width=1, dash=linestyle)), row=1, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Accelerometer2_Y'], mode=mode, name='Y', line=dict(color=line_color, width=1, dash=linestyle)), row=2, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Accelerometer2_Z'], mode=mode, name='Z', line=dict(color=line_color, width=1, dash=linestyle)), row=3, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Accelerometer50_X'], mode=mode, name='X50', line=dict(color=line_color, width=1, dash=linestyle)), row=4, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Accelerometer50_Y'], mode=mode, name='Y50', line=dict(color=line_color, width=1, dash=linestyle)), row=5, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Strain1'], mode=mode, name='Strain 1', line=dict(color=line_color, width=1, dash=linestyle)), row=6, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Strain2'], mode=mode, name='Strain 2', line=dict(color=line_color, width=1, dash=linestyle)), row=7, col=1)
        print("Subplots added")

    def plot_subplots(self, data_file):
        data = pd.read_csv(data_file, header=None, skiprows=1, delimiter=',', dtype=float)
        data.columns = ['Time', 'Accelerometer2_X', 'Accelerometer2_Y', 'Accelerometer2_Z', 'Accelerometer50_X', 'Accelerometer50_Y', 'Strain1', 'Strain2']

        fig = make_subplots(rows=7, cols=1, shared_xaxes=True, subplot_titles=("Accelerometer X2", "Accelerometer Y2", "Accelerometer Z2", "Accelerometer X50", "Accelerometer Y50", "Strain 1", "Strain 2"))
        self.make_subplots_for_data(data, fig, line_color='black')

        fig.update_layout(height=800, width=1350, title_text="Sensor Data", showlegend=False, margin=dict(l=0, r=0, t=0, b=0))

        fig.write_html(self.output_path)
        print("Image saved to ", self.output_path)


# if __name__ == "__main__":
#     import sys

#     output_path = sys.argv[1]
#     data_file_path = sys.argv[2]

#     plotter = Plotter(output_path=output_path)
#     plotter.plot_subplots(data_file_path)

    


""" Case: Plotting line with anomalies """
if __name__ == "__main__":
    import sys

    output_path = sys.argv[1]
    tempDataPath = sys.argv[2]
    tempAnomalyPath = sys.argv[3]

    plotter = Plotter(output_path=output_path)
    plotter.plot_anomalies(tempDataPath, tempAnomalyPath)
    


    