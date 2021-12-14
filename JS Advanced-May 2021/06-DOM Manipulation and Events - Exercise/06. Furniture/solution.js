function solve() {
    let textAreas = document.querySelectorAll('#exercise textarea');
    let buttons = document.querySelectorAll('#exercise button');
    let tableBody = document.querySelector('.table tbody');

    let generateBtn = buttons[0];
    let buyBtn = buttons[1];

    generateBtn.addEventListener('click', (e) => {
        let json = JSON.parse(textAreas[0].value);

        json.forEach(element => {
            let tableRow = document.createElement('tr');

            let tdForImage = document.createElement('td');
            let img = document.createElement('img');
            img.src = element.img;
            tdForImage.appendChild(img);

            tableRow.appendChild(tdForImage);

            let tdForName = document.createElement('td');
            let p = document.createElement('p');
            p.textContent = element.name;
            tdForName.appendChild(p);

            tableRow.appendChild(tdForName);

            let tdForPrice = document.createElement('td');
            let pForPrice = document.createElement('p');
            pForPrice.textContent = element.price;
            tdForPrice.appendChild(pForPrice);

            tableRow.appendChild(tdForPrice);

            let tdForDecFactor = document.createElement('td');
            let pForDecFactor = document.createElement('p');
            pForDecFactor.textContent = element.decFactor;
            tdForDecFactor.appendChild(pForDecFactor);

            tableRow.appendChild(tdForDecFactor);

            let tdForCheckBox = document.createElement('td');
            let checkbox = document.createElement('input');
            checkbox.type = 'checkbox';
            tdForCheckBox.appendChild(checkbox);

            tableRow.appendChild(tdForCheckBox);

            tableBody.appendChild(tableRow);
        });
    });

    buyBtn.addEventListener('click', (e) => {
        let tableRows = Array.from(tableBody.querySelectorAll('tr'));
        
        let buyedProducts = [];
        let totalPrice = 0;
        let averageDecFactor = 0;

        tableRows.forEach(r => {
            let checkbox = r.querySelector('td input');
            
            if(checkbox.checked){
                let paragraphs = r.querySelectorAll('td p');
                
                let product = paragraphs[0].textContent;
                let price = Number(paragraphs[1].textContent);
                let decFactor = Number(paragraphs[2].textContent);

                buyedProducts.push(product);
                totalPrice += price;
                averageDecFactor += decFactor;
            }
        });

        averageDecFactor /= buyedProducts.length;

        let buyedResult = `Bought furniture: ${buyedProducts.join(', ')}\n`;
        buyedResult += `Total price: ${totalPrice.toFixed(2)}\n`;
        buyedResult += `Average decoration factor: ${averageDecFactor}`;

        textAreas[1].textContent = buyedResult;
    });
}