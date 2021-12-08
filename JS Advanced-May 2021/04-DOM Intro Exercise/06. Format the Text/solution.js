function solve() {
  let inputTextArray = document.getElementById('input').value.split('. ');
  let output = document.getElementById('output');

  while (inputTextArray.length > 0) {
    let currResult = inputTextArray.splice(0, 3);

    let p = document.createElement('p');
    let paragraphResult = '';

    currResult.forEach(text => {
      if (!text.includes('.')) {
        paragraphResult += text + '.';
      } else {
        paragraphResult += text;
      }
    });

    p.textContent = paragraphResult;
    output.appendChild(p);
  }
}