import matplotlib.pyplot as plt
import pandas as pd
import plotly.graph_objects as go
from plotly.subplots import make_subplots


class Plotter:
    def __init__(self, output_path: str=None):
        if output_path is None:
            self.output_path = 'output.png'
        else:
            self.output_path = output_path

    def lineplot(self, x, y):
        plt.figure()
        plt.plot(x, y, label='Line Plot')
        plt.scatter(x, y, color='red', label='Scatter Plot')
        plt.legend()
        plt.savefig(self.output_path)

    def plot_anomalies(self, x, y, indices): 
        plt.figure()
        plt.plot(x, y, label='Line Plot')
        plt.scatter([x[i] for i in indices], [y[i] for i in indices], color='red', label='Anomalies')
        plt.legend()
        plt.savefig(self.output_path)
       
    def make_subplots_for_data(self, df, fig, line_color='black', linestyle='solid'):
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Accelerometer2_X'], mode='lines', name='X', line=dict(color=line_color, width=1, dash=linestyle)), row=1, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Accelerometer2_Y'], mode='lines', name='Y', line=dict(color=line_color, width=1, dash=linestyle)), row=2, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Accelerometer2_Z'], mode='lines', name='Z', line=dict(color=line_color, width=1, dash=linestyle)), row=3, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Accelerometer50_X'], mode='lines', name='X50', line=dict(color=line_color, width=1, dash=linestyle)), row=4, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Accelerometer50_Y'], mode='lines', name='Y50', line=dict(color=line_color, width=1, dash=linestyle)), row=5, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Strain1'], mode='lines', name='Strain 1', line=dict(color=line_color, width=1, dash=linestyle)), row=6, col=1)
        fig.add_trace(go.Scatter(x=df['Time'], y=df['Strain2'], mode='lines', name='Strain 2', line=dict(color=line_color, width=1, dash=linestyle)), row=7, col=1)
        print("Subplots added")

    def plot_subplots(self, data_file):
        data = pd.read_csv(data_file, header=None, skiprows=1, delimiter=',', dtype=float)
        data.columns = ['Time', 'Accelerometer2_X', 'Accelerometer2_Y', 'Accelerometer2_Z', 'Accelerometer50_X', 'Accelerometer50_Y', 'Strain1', 'Strain2']

        fig = make_subplots(rows=7, cols=1, shared_xaxes=True, subplot_titles=("Accelerometer X2", "Accelerometer Y2", "Accelerometer Z2", "Accelerometer X50", "Accelerometer Y50", "Strain 1", "Strain 2"))
        self.make_subplots_for_data(data, fig, line_color='black')

        fig.update_layout(height=800, width=1350, title_text="Sensor Data", showlegend=False, margin=dict(l=0, r=0, t=0, b=0))
        # fig.write_image(self.output_path)
        fig.write_html(self.output_path)
        print("Image saved to ", self.output_path)


if __name__ == "__main__":
    import sys

    output_path = sys.argv[1]
    data_file_path = sys.argv[2]

    plotter = Plotter(output_path=output_path)
    plotter.plot_subplots(data_file_path)


""" Case: Plotting line with anomalies """
# if __name__ == "__main__":
#     import sys

#     output_path = sys.argv[1]
#     temp_x_file_path = sys.argv[2]
#     temp_y_file_path = sys.argv[3]
#     temp_indices_file_path = sys.argv[4]

#     with open(temp_x_file_path, 'r') as file:
#         x = list(map(float, file.readline().strip().split(',')))

#     with open(temp_y_file_path, 'r') as file:
#         y = list(map(float, file.readline().strip().split(',')))

#     with open(temp_indices_file_path, 'r') as file:
#         indices = list(map(int, file.readline().strip().split(',')))

#     plotter = Plotter(output_path=output_path)
#     plotter.plot_anomalies(x, y, indices)


    