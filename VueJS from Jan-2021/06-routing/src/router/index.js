import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

import Home from '../views/Home-page.vue';
import Form from '../views/Form-page.vue';

import bookRoutes from './books.js';

const routes = [
    { path: '/', name: 'home', component: Home }, //Можем да използваме и наименувани раутове и после в router-link тага да пишем името на раута, вместо url-а до него. Полезно е когато имаме дълги url-и и вместо да пишем тях, може да напишем името на раута.
    ...bookRoutes,
    { path: '/form', component: Form },
    // { path: '*', redirect: '/'} //Това е wild card. В случая, ако напишем страница, която не съществува в раута, ще ни редиректне към хоум страницата. Wild card се слага винаги най-долу, защото това е масив и го чете от горе надолу и като стигне до тук, му се казва, каквото и да напишем, редиректни.
];

const router = new VueRouter({
    routes,
    mode: 'history'
});

import { getUser } from '../utils/authUtils.js';
router.beforeEach((to, from, next) => {
    // console.log('to: ', to);
    // console.log('from: ', from);
    
    const user = getUser();
    
    if(to.name == 'home' || user.isAuth) {
        next();
    } else {
        next({ name: 'home'});
    }
}); //Route guard

export default router;