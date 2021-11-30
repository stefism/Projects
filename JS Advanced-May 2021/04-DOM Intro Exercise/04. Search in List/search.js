function search() {
   let towns = Array.from(document.querySelectorAll('#towns li'));
   let searchText = document.getElementById('searchText');
   let result = document.getElementById('result');

   let wordCount = 0;

   towns.map((town) => {
      town.style.fontWeight = 'normal';
      town.style.textDecoration = 'none';

      if (town.textContent.includes(searchText.value)) {
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         wordCount ++;
      }
   });
   
   result.textContent = `${wordCount} matches found`;
   searchText.value = '';
}
