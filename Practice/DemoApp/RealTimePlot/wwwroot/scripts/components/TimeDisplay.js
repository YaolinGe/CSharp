export function ConvertStartTimeToLocal(utcDateTime) {
    const utcString = new Date(`${utcDateTime} UTC`); 
    return utcString.toLocaleString(); 
}

export function sayHello() {
    alert("Hello"); 
}

export function sayHi(name) {
    alert(`Hello ${name}!`); 
}