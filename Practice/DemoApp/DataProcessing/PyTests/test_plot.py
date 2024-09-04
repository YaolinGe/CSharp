from unittest import TestCase
from plot import Plotter
import pandas as pd


class TestPlot(TestCase):
    def setUp(self) -> None:
        self.plotter = Plotter(output_path="C:/Users/nq9093/Downloads/output_anomaly.html")
        # self.filePath = "C:/Users/nq9093/Downloads/normalizedData.csv"
        # self.df = pd.read_csv(self.filePath)
        self.data_path = r"C:\Users\nq9093\AppData\Local\Temp\tmpf2xuix.tmp"
        self.anomaly_path = r"C:\Users\nq9093\AppData\Local\Temp\tmpc1pcs5.tmp"

    # def test_subplots(self) -> None:
        # self.plotter.plot_subplots(self.filePath)

    def test_plot_anomalies(self) -> None:
        self.plotter.plot_anomalies(self.data_path, self.anomaly_path)
