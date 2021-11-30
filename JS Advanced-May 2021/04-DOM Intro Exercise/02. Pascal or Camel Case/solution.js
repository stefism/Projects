function solve() {
  let textElement = document.getElementById('text');
  let namingElement = document.getElementById('naming-convention');

  let result = document.getElementById('result');

  let words = textElement.value.split(' ');

  switch (namingElement.value) {
    case 'Camel Case':
      result.textContent = convertText('Camel', words)
      break;

    case 'Pascal Case':
      result.textContent = convertText('Pascal', words)
      break;
  
    default:
      result.textContent = 'Error!';
      break;
  }

  function convertText(type, textArray){
    let index = 0
    let result = '';

    if (type == 'Camel') {
      result += textArray[0].toLowerCase();
      index = 1;
    }

    for (let i = index; i < textArray.length; i++) {
      textArray[i] = textArray[i].toLowerCase();
      result += textArray[i].charAt(0).toUpperCase() + textArray[i].slice(1);
    }

    return result;
  }
}