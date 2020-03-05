function stringLength(string1, string2, string3) {
    let srtLength = string1.length + string2.length + string3.length;
    let averageLength = Math.floor(srtLength / 3);
    
    console.log(srtLength);
    console.log(averageLength);
}

stringLength('chocolate', 'ice cream', 'cake')