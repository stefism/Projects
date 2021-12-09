function solve() {
   let card = document.querySelector('.shopping-cart');
   let textArea = document.querySelector('.shopping-cart textarea');

   let products = [];
   let totalPrice = 0;

   card.addEventListener('click', (e) => {
      if(e.target.tagName == 'BUTTON'){
         if(e.target.className == 'checkout'){
            if(products.length == 0){
               return;
            }

            textArea.textContent += `You bought ${products.join(', ')} for ${totalPrice.toFixed(2)}.`;

            let buttons = document.querySelectorAll('.shopping-cart button');
            buttons.forEach(b => b.disabled = true);
         } else {
         let product = e.target.parentNode.parentNode;
         let productTitle = product.querySelector('.product-title').textContent;
         let productPrice = product.querySelector('.product-line-price').textContent;

         textArea.textContent += `Added ${productTitle} for ${productPrice} to the cart.\n`;

         if(!products.includes(productTitle)){
            products.push(productTitle);
         }

         totalPrice += Number(productPrice);
         }  
      }
   });
}