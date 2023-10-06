import os

filepath = os.getcwd() + '/'
files = os.listdir(filepath)
for file in files: 
    if file.endswith('.py'):
        continue

    print(file)
    print(os.listdir(filepath + file))
