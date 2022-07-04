import Vue from 'vue';
import App from './App.vue';
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import locale from 'element-ui/lib/locale/lang/bg';

Vue.use(ElementUI, { locale });

Vue.config.productionTip = false;

Vue.filter('rev-global', function(value) {
  return value.split('').reverse().join('') + ' -glob';
}); //Преди new Vue({ ... и т.н. реда трябва се сложи, иначе гърми.

Vue.directive('highlight', function(element, binding) {
  console.log('binding: ', binding);
  element.style.backgroundColor = binding.value;
}); //Къстъм директива.

Vue.directive('event', function(element, binding) {
  console.log('element: ', element);
  console.log('binding: ', binding);
}); //Къстъм директива.

new Vue({
  render: h => h(App),
}).$mount('#app')


