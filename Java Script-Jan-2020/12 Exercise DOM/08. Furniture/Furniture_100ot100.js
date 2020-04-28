function solve() {
    let buttons = document.getElementsByTagName('button');
    let generateBtn = buttons[0];
    let textAreas = document.getElementsByTagName('textarea');
    let namesOfFurnitures = [];
    let totalPrice = 0;
    let totalDecorations = 0;
    let counter = 0;

    generateBtn.addEventListener('click', () => {
        let inputOfFurnitures = textAreas[0].value;
        inputOfFurnitures = JSON.parse(inputOfFurnitures);

        for (let i = 0; i < inputOfFurnitures.length; i++) {
            fillUpTableWithFurnitures(inputOfFurnitures[i]);
        }
    });

    let buyBtn = buttons[1];

    buyBtn.addEventListener('click', () => {
        let inputs = document.getElementsByTagName('input');
        Array.from(inputs);

        for (const input of inputs) {
            if (input.checked === true) {
                let parent = input.parentElement.parentElement.children;
                let name = parent[1].innerText.trim();
                let price = +parent[2].innerText;
                let decorFac = +parent[3].innerText;

                namesOfFurnitures.push(name);
                totalPrice += price;
                totalDecorations += decorFac;
                counter++;

                textAreas[1].value = getOutput(
                    namesOfFurnitures,
                    totalPrice,
                    totalDecorations
                );
            }
        }
    });

    function fillUpTableWithFurnitures(furniture) {
        let tbody = document.getElementsByTagName('tbody')[0];
        let row = tbody.insertRow(-1);

        let img = document.createElement('img');
        img.src = furniture.img;

        let input = document.createElement('input');
        input.setAttribute('type', 'checkbox');

        row.insertCell(0).appendChild(img);
        let p1 = document.createElement('p');
        let p2 = document.createElement('p');
        let p3 = document.createElement('p');
        row.insertCell(1).appendChild(p1).innerHTML = furniture.name;
        row.insertCell(2).appendChild(p2).innerHTML = furniture.price;
        row.insertCell(3).appendChild(p3).innerHTML = furniture.decFactor;
        row.insertCell(4).appendChild(input);
    }

    function getOutput(namesOfFurnitures, totalPrice, totalDecorations) {
        // let sum = selectedFunitures['averageDecFac'].reduce((a, b) => a + b, 0);
        let average = totalDecorations / counter;

        return (
            `Bought furniture: ${namesOfFurnitures.join(', ')}\n` +
            `Total price: ${totalPrice.toFixed(2)}\n` +
            `Average decoration factor: ${average}`
        );
    }
}