function getData() {
    return Math.random(); 
}

function createPlot() {
    Plotly.plot('dataChart', [{
        y: [getData()],
        type: 'line'
    }])
}

function sayHello2() {
    alert("Hello, you made it 2 times!")
}