import { sumNumbers as sum, numberProduct } from './module.js'; //Така импортваме функцията.
//Модулите не отиват в глобалния скоуп.
//При наименуваните експорти, при импорта, трябва да напишеш точно името на функцията, така както се казва във файла от който експортваме, но можем ако искаме после да я преименуваме с ключовата дума "as".
//Можем да импортираме всичко от даден модул със;
//import * as numberOperation from './module.js';
import { myArr } from './data.js';

console.log(sum(5, 3));
console.log(numberProduct(5, 3));

console.log(myArr);
myArr.push(4);
console.log(myArr);
