import Vue from 'vue';
import App from './App.vue';

import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import locale from 'element-ui/lib/locale/lang/en';

import router from './router';
// Използваме версия на VueRouter - тройка. (3.5.4). При инсталирането му казваме 
// npm install vue-router@3
// Иначе инсталира верся 4, която е с различен начин на работа и инсталиране.

Vue.use(ElementUI, { locale });

Vue.config.productionTip = false;

new Vue({
  render: h => h(App),
  router
}).$mount('#app');