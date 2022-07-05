import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

import Home from '../views/Home-page.vue';
import Form from '../views/Form-page.vue';
import BookList from '../views/BookList-page.vue';


const routes = [
    { path: '/', component: Home },
    { path: '/magic-books', component: BookList },
    { path: '/form', component: Form },
];

const router = new VueRouter({
    routes,
});

export default router;