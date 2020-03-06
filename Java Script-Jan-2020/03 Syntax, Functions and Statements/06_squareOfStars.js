function squareOfStars(starsNumber = 5){
    let line = '';
    for (let i = 0; i < starsNumber; i++) {
        
        for (let j = 0; j < starsNumber; j++) {
            line += '* ';
            
        }

        console.log(line);
        line = '';
    }
}

squareOfStars(3);