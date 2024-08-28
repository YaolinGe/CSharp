import matplotlib.pyplot as plt
import sys

def generate_plot(x, y, output_path):
    plt.plot(x, y)
    plt.savefig(output_path)

if __name__ == "__main__":
    x = list(map(float, sys.argv[1].split(',')))
    y = list(map(float, sys.argv[2].split(',')))
    output_path = sys.argv[3]
    generate_plot(x, y, output_path)
    