import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

import firebase from 'firebase/app';
import 'firebase/auth';

import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
Vue.component('font-awesome-icon', FontAwesomeIcon);

Vue.config.productionTip = false;

let app;
firebase.auth().onAuthStateChanged(() => {
  if(!app) {
    new Vue({
      router,
      store,
      render: (h) => h(App),
    }).$mount("#app");
  }
}); //Правим това, за да изчакаме firebase да провери дали има логнат юзер и чак тогава да стартира Vue инстанция, за да може да вземем информацията за юзъра в началната страница на приложението.