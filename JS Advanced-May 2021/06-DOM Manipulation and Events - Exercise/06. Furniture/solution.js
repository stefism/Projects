function solve() {
    let textAreas = document.querySelectorAll('#exercise textarea');
    let buttons = document.querySelectorAll('#exercise button');
    let tableBody = document.querySelector('.table tbody');

    let generateBtn = buttons[0];
    let buyBtn = buttons[1]; 

    generateBtn.addEventListener('click', (e) => {
        let json = JSON.parse(textAreas[0].value);

        json.forEach(element => {
            let tableRow = createTableRow(element);
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

            if (checkbox.checked) {
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

    function createTableRow(element) {
        let tableRow = document.createElement('tr');

        let tdForImage = createTableDataElement('img', element.img);
        tableRow.appendChild(tdForImage);

        let tdForName = createTableDataElement('p', element.name);
        tableRow.appendChild(tdForName);

        let tdForPrice = createTableDataElement('p', element.price);
        tableRow.appendChild(tdForPrice);

        let tdForDecFactor = createTableDataElement('p', element.decFactor);
        tableRow.appendChild(tdForDecFactor);

        let tdForCheckBox = createTableDataElement('input', 'checkbox');
        tableRow.appendChild(tdForCheckBox);

        return tableRow;
    }

    function createTableDataElement(childElement, childContent) {
        let td = document.createElement('td');
        let child = document.createElement(childElement);

        if (childElement == 'img') {
            child.src = childContent;
        } else if (childElement == 'p') {
            child.textContent = childContent;
        } else if (childElement == 'input') {
            child.type = childContent;
        }

        td.appendChild(child);

        return td;
    }
}