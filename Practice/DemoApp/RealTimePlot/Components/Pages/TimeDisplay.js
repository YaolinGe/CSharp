function ConvertStartTimeToLocal(utcDateTime) {
    const utcString = new Date(`${utcDateTime} UTC`); 
    return utcString.toLocaleString(); 
}

function sayHello() {
    alert("Hello"); 
}