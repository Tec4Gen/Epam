function MyCustomCalc(str){
    var total= 0;
    var str= str.match(/[+\-]*(\.\d+|\d+(\.\d+)?)/g) || [];
    while(str.length){
        total+= parseFloat(str.shift());
    }
    return total;
}

let string='3.5 +4*10.555-5.322222 /5 = ';
console.log(MyCustomCalc(string).toFixed(2));