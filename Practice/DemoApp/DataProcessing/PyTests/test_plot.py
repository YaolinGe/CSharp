from unittest import TestCase
from plot import Plotter
import pandas as pd


class TestPlot(TestCase):
    def setUp(self) -> None:
        self.plotter = Plotter(output_path="C:/Users/nq9093/Downloads/output.html")
        self.filePath = "C:/Users/nq9093/Downloads/normalizedData.csv"
        self.df = pd.read_csv(self.filePath)

    def test_subplots(self) -> None:
        self.plotter.plot_subplots(self.filePath)

